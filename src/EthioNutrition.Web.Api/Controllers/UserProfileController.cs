using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EthioNutrition.Web.Api.Models;
using EthioNutrition.Web.Common.Security;
using EthioNutrition.Web.Api.TypeMappers;
using EthioNutrition.Web.Api.HttpFetchers;
using NHibernate;
using EthioNutrition.Web.Common;

namespace EthioNutrition.Web.Api.Controllers
{
    [LoggingNHibernateSessionAttribute]
    public class UserProfileController : ApiController
    {
        private readonly ISession _session;
        private readonly IUserProfileMapper _userProfileMapper;
        private readonly IHttpUserProfileFetcher _userProfileFetcher;
        private readonly IUserSession _userSession;
        private readonly IUserManager _userManager;
        
        //Constructor
        public UserProfileController(ISession session, IUserProfileMapper userMapper, IHttpUserProfileFetcher userFetcher
            , IUserSession userSession, IUserManager userManager)
        {
            _session = session;
            _userSession = userSession;
            _userProfileFetcher = userFetcher;
            _userProfileMapper = userMapper;
            _userManager = userManager;
            
        }
        public UserProfile Get(Guid userId, long profileId)
        {
            if (userId == _userSession.UserId)
            {
                return _userProfileMapper.CreateUserProfile(_userProfileFetcher.GetUserProfile(profileId));
            }
            
            return null;
        }
        public UserProfile Get()
        {
            var user = _session.Get<Data.Models.User>(_userSession.UserId);
            return _userProfileMapper.CreateUserProfile(user.profile);
            
        }
        public HttpResponseMessage Put(HttpRequestMessage request, UserProfile profile, Guid UserId)
        {
            return null;
        }

    }
}
