using EthioNutrition.Web.Common.Security;
using NHibernate;
using System;
using System.Net.Http;
using System.Web.Http;

namespace EthioNutrition.Web.Api.HttpFetchers
{
    public class HttpUserProfileFetcher: IHttpUserProfileFetcher
    {
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public HttpUserProfileFetcher(ISession session, IUserSession userSession)
        {
            _session = session;
            _userSession = userSession;
        }
        public Data.Models.UserProfile GetUserProfile(long profileId)
        {
            var userProfile= _session.Get<Data.Models.UserProfile>(profileId);

            if (userProfile == null)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage
                    {
                        StatusCode= System.Net.HttpStatusCode.NotFound,
                        ReasonPhrase= string.Format("User Profile Not created for current user")
                    }
                    );
            }
            return userProfile;
        }


        public Data.Models.UserProfile GetCurrentUserProfile()
        {
            var user = _session.Get<Data.Models.User>(_userSession.UserId);
            return GetUserProfile(user.profile.ProfileID);
            
        }
    }
}