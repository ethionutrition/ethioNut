
namespace EthioNutrition.Web.Common.Security
{
    public interface IUserNameCheck
    {
         void CheckUserName(string email);
         bool Available { get; }
    }
}
