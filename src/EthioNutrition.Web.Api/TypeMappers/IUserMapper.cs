using EthioNutrition.Web.Api.Models;
using System;

namespace EthioNutrition.Web.Api.TypeMappers
{
  public interface IUserMapper
    {
      User CreateUser(string firstname, string lastname, string email, Guid userId);
      User CreateUser(Data.Models.User modelUser);
    }
}
