﻿using EthioNutrition.Web.Api.Models;
namespace EthioNutrition.Web.Api
{
    public interface IUserManager
    {
        User CreateUser(string email, string password, string firstname, string lastname);
    }
}