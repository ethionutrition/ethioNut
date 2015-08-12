using EthioNutrition.Web.Api.Models;
using EthioNutrition.Web.Common.Security;
using System.Collections.Generic;

namespace EthioNutrition.Web.Api.TypeMappers
{
    public class UserProfileMapper: IUserProfileMapper
    {
        private readonly IUserSession _userSession;
        public UserProfileMapper(IUserSession userSession)
        {
            _userSession = userSession;
        }

        public Models.UserProfile CreateUserProfile(Data.Models.UserProfile profile)
        {
            return new Models.UserProfile
            {
                ProfileID= profile.ProfileID,
                UserBirthDate= profile.UserBirthDate,
                UserBMI= profile.UserBMI,
                UserHeightInMeter= profile.UserHeightInMeter,
                UserWeightInKg= profile.UserWeightInKg,
                Links = new List<Link>
                {
                    new Link{
                        Title="self",
                        Rel="self",
                        Href="/api/user/"+ _userSession.UserId.ToString()+"/profile/"+ profile.ProfileID
}
                }
            };
        }
    }
}