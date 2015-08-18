using EthioNutrition.Common;
using EthioNutrition.Data;
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
        private readonly IDateTime _dateTime;

        public UserManager(IMembershipInfoProvider membershipAdapter, IUserRepository userRepository, IUserMapper userMapper, ISession session,IDateTime datetime)
        {
            _membershipAdapter = membershipAdapter;
            _userRepository = userRepository;
            _userMapper = userMapper;
            _session = session;
            _dateTime = datetime;
        }
        [LoggingNHibernateSession]
        public Models.User CreateUser(string email, string password, string firstname, string lastname)
        {
            var wrapper = _membershipAdapter.CreateUser(email, password);

            var userProfile = new Data.Models.UserProfile { UserBirthDate= _dateTime.UtcNow };
            _session.Save(userProfile);

            _userRepository.SaveUser(wrapper.UserId, firstname, lastname,userProfile.ProfileID);
            var user = _userMapper.CreateUser(firstname, lastname, email, wrapper.UserId);
            return user;
        }
    }
}