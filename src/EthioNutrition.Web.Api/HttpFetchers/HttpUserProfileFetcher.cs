using NHibernate;
using System;
using System.Net.Http;
using System.Web.Http;

namespace EthioNutrition.Web.Api.HttpFetchers
{
    public class HttpUserProfileFetcher: IHttpUserProfileFetcher
    {
        private readonly ISession _session;

        public HttpUserProfileFetcher(ISession session)
        {
            _session = session;
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
    }
}