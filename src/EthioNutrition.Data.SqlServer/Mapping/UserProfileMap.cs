using EthioNutrition.Data.Models;
using System;

namespace EthioNutrition.Data.SqlServer.Mapping
{
    public class UserProfileMap: VersionedClassMap<UserProfile>
    {
        public UserProfileMap()
        {
            Id(x => x.ProfileID);
            Map(x => x.UserBirthDate).Not.Nullable();
            Map(x => x.UserHeightInMeter).Not.Nullable();
            Map(x => x.UserWeightInKg).Not.Nullable();
            Map(x => x.UserBMI).Not.Nullable();
        }
    }
}
