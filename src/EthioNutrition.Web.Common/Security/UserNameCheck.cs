using System;
using System.Web.Security;

namespace EthioNutrition.Web.Common.Security
{
    public class UserNameCheck: IUserNameCheck
    {
        public bool Available { get; private set; }
        public void CheckUserName(string email)
        {
            Available=false;   
            var user = Membership.GetUserNameByEmail(email);
            if (user == null) Available = true;           
        }
    }
}