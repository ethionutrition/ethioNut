using EthioNutrition.Web.Api.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EthioNutrition.Common;
using NHibernate;
using NHibernate.Linq;
using EthioNutrition.Web.Api.TypeMappers;
using EthioNutrition.Web.Api.HttpFetchers;
using EthioNutrition.Web.Common.Security;
using System.Collections.Generic;
using EthioNutrition.Web.Common;
using System.Web.Security;

namespace EthioNutrition.Web.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly ISession _session;
        private readonly IUserMapper _userMapper;
        private readonly IHttpUserFetcher _userFetcher;
        private readonly IUserSession _userSession;
        private readonly IUserManager _userManager;
        private readonly IUserNameCheck _usernamecheck;

        //Constructor
        public UserController(ISession session, IUserMapper userMapper, IHttpUserFetcher userFetcher
            , IUserSession userSession, IUserManager userManager, IUserNameCheck usernamecheck)
        {
            _session = session;
            _userSession = userSession;
            _userFetcher = userFetcher;
            _userMapper = userMapper;
            _userManager = userManager;
            _usernamecheck = usernamecheck;
        }
        
        public User Get()
        {
            var user = _userFetcher.GetUser(_userSession.UserId);
            return _userMapper.CreateUser(user);
        }
        //[Authorize (Roles="UserCreators")]
        [UserCreatorAuthorized]
        public HttpResponseMessage Post(HttpRequestMessage request, User user)
        {
            _usernamecheck.CheckUserName(user.Email);
            if (_usernamecheck.Available)
            {
                var newUser = _userManager.CreateUser(user.Email, user.Password, user.FirstName, user.LastName);

                var href = newUser.Links.First(x => x.Rel == "self").Href;

                var response = request.CreateResponse(HttpStatusCode.Created, newUser);
                response.Headers.Add("Location", href);
                return response;
            }

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NotAcceptable,
                ReasonPhrase = string.Format("Email {0} already exists", user.Email)
            };
            
        }
        [LoggingNHibernateSessionAttribute]
        public HttpResponseMessage Delete()
        {
            //var user = _session.Get<Data.Models.User>(_userSession.UserId);
            //if (!Roles.GetRolesForUser(user.Email).Contains("Administrator"))
            //{

            //    _session.Delete(user);

            //    return new HttpResponseMessage
            //    {
            //        StatusCode = HttpStatusCode.OK,
            //        ReasonPhrase = string.Format("user Deleted succesfully")
            //    };
            //}
            //return new HttpResponseMessage
            //{
            //    StatusCode = HttpStatusCode.Forbidden,
            //    ReasonPhrase = string.Format("Email {0} cant be deleted Deleted succesfully", user.Email)
            return null;
            //};
            
        }
    }
}
