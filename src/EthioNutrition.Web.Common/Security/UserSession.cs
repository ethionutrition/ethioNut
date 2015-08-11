using System;
using System.Security.Claims;

namespace EthioNutrition.Web.Common.Security
{
    public class UserSession: IUserSession
    {
        //ClaimsPrincipal is where the GenericPrincipal derives from
        public UserSession(ClaimsPrincipal principal)
        {
            UserId = Guid.Parse(principal.FindFirst(ClaimTypes.Sid).Value);
            Email = principal.FindFirst(ClaimTypes.Email).Value;
            FirstName = principal.FindFirst(ClaimTypes.GivenName).Value;
            LastName = principal.FindFirst(ClaimTypes.Surname).Value;
        }
        public Guid UserId { get; private set; }

        public string Email { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
    }
}
