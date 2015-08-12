using NHibernate;
using System;
using System.Net.Http;
using System.Web.Http;

namespace EthioNutrition.Web.Api.HttpFetchers
{
    public class HttpUserFetcher: IHttpUserFetcher
    {
        private readonly ISession _session;
        public HttpUserFetcher(ISession session)
        {
            _session = session;
        }
        public Data.Models.User GetUser(Guid userId)
        {
            var user = _session.Get<Data.Models.User>(userId);
            if (user == null)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage
                    {
                        StatusCode = System.Net.HttpStatusCode.NotFound,
                        ReasonPhrase = string.Format("user {0} not found", userId)
                    }
                    );
            }
            return user;
        }
    }
}