using EthioNutrition.Web.Api.Models;
using System;
namespace EthioNutrition.Web.Api.TypeMappers
{
    public interface IUserProfileMapper
    {
        UserProfile CreateUserProfile(Data.Models.UserProfile profile);
    }
}
