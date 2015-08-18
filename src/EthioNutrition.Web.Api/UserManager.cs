using EthioNutrition.Data;
using EthioNutrition.Web.Api.TypeMappers;
using EthioNutrition.Web.Common.Security;
using System;

namespace EthioNutrition.Web.Api
{
    public class UserManager: IUserManager
    {
        private readonly IMembershipInfoProvider _membershipAdapter;
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _userMapper;

        public UserManager(IMembershipInfoProvider membershipAdapter, IUserRepository userRepository, IUserMapper userMapper)
        {
            _membershipAdapter = membershipAdapter;
            _userRepository = userRepository;
            _userMapper = userMapper;
        }
        public Models.User CreateUser(string email, string password, string firstname, string lastname)
        {
            var wrapper = _membershipAdapter.CreateUser(email, password);
            _userRepository.SaveUser(wrapper.UserId, firstname, lastname);
            var user = _userMapper.CreateUser(firstname, lastname, email, wrapper.UserId);
            return user;
        }
    }
}