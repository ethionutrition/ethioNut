using EthioNutrition.Web.Api.TypeMappers;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using EthioNutrition.Web.Api.HttpFetchers;
using EthioNutrition.Web.Common.Security;

namespace EthioNutrition.Web.Api.Controllers
{
    [AdministratorAuthorized]
    public class UsersController : ApiController
    {
        private readonly ISession _session;
        private readonly IUserMapper _userMapper;
        private readonly IHttpUserFetcher _userFetcher;

        public UsersController(ISession session, IUserMapper usermapper, IHttpUserFetcher userfetcher)
        {
            _session = session;
            _userMapper = usermapper;
            _userFetcher = userfetcher;
        }
        public IEnumerable<Models.User> Get()
        {
            var user = _session.Query<Data.Models.User>().Select(_userMapper.CreateUser);
            return user;
        }
        public Models.User Get(Guid id)
        {
            var user = _userFetcher.GetUser(id);
            return _userMapper.CreateUser(user);
        }

    }
}
