using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
namespace EthioNutrition.Web.Common
{
    public interface IWebApi
    {
       Task<string> GetApiToken(string userName,string password, string apiBaseUri);
       Task<JArray> GetJArrayResponse(string token, string apiBaseUri, string requestPath);
       Task<JObject> GetJObjectResponse(string token, string apiBaseUri, string requestPath,object modelObject);
    }
}
