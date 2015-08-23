using EthioNutrition.Data.Models;
using System;

namespace EthioNutrition.Web.Api.HttpFetchers
{
    public interface IHttpUserProfileFetcher
    {
        UserProfile GetUserProfile(long profileId);
        UserProfile GetCurrentUserProfile();
    }
}
