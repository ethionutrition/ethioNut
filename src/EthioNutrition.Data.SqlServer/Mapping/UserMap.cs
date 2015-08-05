using EthioNutrition.Data.Models;
using System;
namespace EthioNutrition.Data.SqlServer.Mapping
{
    public class UserMap: VersionedClassMap<User>
    {
        public UserMap()
        {
            Table("AllUsers");
            Id(x => x.UserId).CustomType<Guid>();
            Map(x => x.FirstName).Not.Nullable();
            Map(x => x.LastName).Not.Nullable();
            Map(x => x.Email).Not.Nullable();

            References(x => x.profile, "ProfileId");

        }
    }
}
/*Example for many to many rln
 * HasManyToMany(x => x.Users)
          .Access.ReadOnlyPropertyThroughCamelCaseField(Prefix.Underscore)
          .Table("TaskUser")
          .ParentKeyColumn("TaskId")
          .ChildKeyColumn("UserId");*/