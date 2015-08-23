using EthioNutrition.Data.Models;
using System;

namespace EthioNutrition.Web.Api.HttpFetchers
{
    public interface IHttpUserFetcher
    {
        User GetUser(Guid userId);
        User GetCurrentUser();
    }
}
