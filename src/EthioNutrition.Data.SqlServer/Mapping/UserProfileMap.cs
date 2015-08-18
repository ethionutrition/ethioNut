using EthioNutrition.Data.Models;
using System;

namespace EthioNutrition.Data.SqlServer.Mapping
{
    public class UserProfileMap: VersionedClassMap<UserProfile>
    {
        public UserProfileMap()
        {
            Id(x => x.ProfileID);
            Map(x => x.UserBirthDate).Nullable();
            Map(x => x.UserHeightInMeter).Nullable();
            Map(x => x.UserWeightInKg).Nullable();
            Map(x => x.UserBMI).Nullable();
        }
    }
}
