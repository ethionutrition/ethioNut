using System;
namespace EthioNutrition.Web.Common.Security
{
    public interface IUserSession
    {
        Guid UserId { get;}
        string Email { get; }
        string FirstName { get;}
        string LastName { get; }
    }
}
