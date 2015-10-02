using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
namespace EthioNutrition.Web.Common
{
    public interface IWebApiToken
    {
       Task<string> GetApiToken(string userName,string password, string apiBaseUri);
       Task<JArray> GetRequest(string token, string apiBaseUri, string requestPath);
       //Task<Type> GetRequest(string token, string apiBaseUri, string requestPath);
    }
}
