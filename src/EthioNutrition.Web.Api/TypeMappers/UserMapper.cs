using EthioNutrition.Web.Api.Models;
using System;
using System.Collections.Generic;

namespace EthioNutrition.Web.Api.TypeMappers
{
    public class UserMapper: IUserMapper
    {
        private readonly IUserProfileMapper _userProfileMapper;
        public UserMapper(IUserProfileMapper userProfileMapper)
        {
            _userProfileMapper = userProfileMapper;
        }
        public Models.User CreateUser(string firstname, string lastname, string email, Guid userId)
        {
            return new User
            {
                UserId=userId,
                Email=email,
                FirstName=firstname,
                LastName= lastname
            };
        }

        public Models.User CreateUser(Data.Models.User modelUser)
        {
            var user= new User
            {
                 
                UserId = modelUser.UserId,
                Email = modelUser.Email,
                FirstName = modelUser.FirstName,
                LastName = modelUser.LastName,
                profile= _userProfileMapper.CreateUserProfile(modelUser.profile)
            };
            user.Links = new List<Link>
            {
                new Link
                {
                    Title="self",
                    Rel="self",
                    Href="api/user/"+ user.UserId
                },
                new Link
                {
                    Title="UserProfile",
                    Rel="UserProfile",
                    Href="api/user/"+user.UserId.ToString()+"/profile"
                }
            };
            return user;
           
        }

    }
}