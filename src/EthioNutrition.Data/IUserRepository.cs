using EthioNutrition.Data.Models;
using System;
namespace EthioNutrition.Data
{
   public interface IUserRepository
    {
       void SaveUser(Guid userId, string firstname, string lastname, long profileid);
       User GetUser(Guid userId);
    }
}
