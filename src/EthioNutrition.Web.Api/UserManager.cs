using EthioNutrition.Common;
using EthioNutrition.Data;
using EthioNutrition.Web.Api.HttpFetchers;
using EthioNutrition.Web.Api.TypeMappers;
using EthioNutrition.Web.Common;
using EthioNutrition.Web.Common.Security;
using NHibernate;
using System;

namespace EthioNutrition.Web.Api
{
    public class UserManager: IUserManager
    {
        private readonly IMembershipInfoProvider _membershipAdapter;
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;
        private readonly ISession _session;
        private readonly IProfileManager _profileManager;
        private readonly IHttpUserFetcher _UserFetcher;

        public UserManager(IMembershipInfoProvider membershipAdapter, IUserRepository userRepository, 
            IUserMapper userMapper, ISession session, IProfileManager profileManager, IHttpUserFetcher userfetcher)
        {
            _membershipAdapter = membershipAdapter;
            _userRepository = userRepository;
            _userMapper = userMapper;
            _session = session;
            _profileManager = profileManager;
            _UserFetcher = userfetcher;
        }
        [LoggingNHibernateSession]
        public Models.User CreateUser(string email, string password, string firstname, string lastname)
        {
            var wrapper = _membershipAdapter.CreateUser(email, password);
            var profileId = _profileManager.CreateProfile();

            _userRepository.SaveUser(wrapper.UserId, firstname, lastname, profileId);

            var user = _userMapper.CreateUser(_UserFetcher.GetUser(wrapper.UserId));
            return user;
        }
    }
}