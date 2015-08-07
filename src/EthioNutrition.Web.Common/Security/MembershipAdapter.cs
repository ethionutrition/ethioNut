using System;
using System.Web.Security;

namespace EthioNutrition.Web.Common.Security
{
    public class MembershipAdapter: IMembershipInfoProvider
    {
        public MembershipUserWrapper GetUser(string email)
        {
            var user = Membership.GetUser(email);
            return user == null ? null : CreateMembershipUserWrapper(user);
        }

        private MembershipUserWrapper CreateMembershipUserWrapper(MembershipUser user)
        {
            return new MembershipUserWrapper
            {
                UserID = Guid.Parse(user.ProviderUserKey.ToString()),
                Email= user.Email
            };
        }

        public MembershipUserWrapper GetUser(Guid userId)
        {
            var user = Membership.GetUser(userId);
            return user == null ? null : CreateMembershipUserWrapper(user);
        }

        public MembershipUserWrapper CreateUser(string email, string password)
        {
            var user = Membership.CreateUser(email, password, email);
            return CreateMembershipUserWrapper(user);
        }

        public bool ValidateUser(string email, string password)
        {
            return Membership.ValidateUser(email, password);
        }

        public string[] GetRolesForUser(string email)
        {
            return Roles.GetRolesForUser(email);
        }
    }
}
