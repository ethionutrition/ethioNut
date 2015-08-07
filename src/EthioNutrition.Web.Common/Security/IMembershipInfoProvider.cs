using System;

namespace EthioNutrition.Web.Common.Security
{
    public interface IMembershipInfoProvider
    {
        MembershipUserWrapper GetUser(string email);
        MembershipUserWrapper GetUser(Guid userId);
        MembershipUserWrapper CreateUser(string email, string password);
        bool ValidateUser(string email, string password);
        string[] GetRolesForUser(string email);
    }
}
