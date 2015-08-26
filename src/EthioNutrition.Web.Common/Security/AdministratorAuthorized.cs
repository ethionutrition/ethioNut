using System;
using System.Web.Http;

namespace EthioNutrition.Web.Common.Security
{
    public class AdministratorAuthorized: AuthorizeAttribute
    {
        public AdministratorAuthorized()
        {
            Roles = "Administrators";
        }
    }
    public class UserCreatorAuthorized : AuthorizeAttribute
    {
        public UserCreatorAuthorized()
        {
            Roles = "UserCreators";
        }
    }
}
