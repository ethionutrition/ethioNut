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

namespace EthioNutrition.Web.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly ISession _session;
        private readonly IUserMapper _userMapper;
        private readonly IHttpUserFetcher _userFetcher;

        //Constructor
        public UserController(ISession session, IUserMapper userMapper, IHttpUserFetcher userFetcher)
        {
            _session = session;
            _userFetcher = userFetcher;
            _userMapper = userMapper;
        }

        [Queryable]
        public IQueryable<Data.Models.User> Get()
        {
            return _session.Query<Data.Models.User>();
        }

        public User Get(Guid id)
        {
            var user = _userFetcher.GetUser(id);
            var userForClient = _userMapper.CreateUser(user);
            return userForClient;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, User user)
        {
            //var response = request.CreateResponse(HttpStatusCode.Created, newUser);
            //response.Headers.Add("Location", Href);
            throw new System.NotImplementedException();
        }
        public HttpResponseMessage Delete(Guid id)
        {
            return null;
        }
    }
}
