using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using EthioNutrition.Common;
namespace EthioNutrition.Web.Common
{
    public class WebApi : IWebApi
    {
        private readonly ApiResponseFormat responseFormat= new ApiResponseFormat();

        //public WebApi(IApiResponseFormat _responseFormat)
        //{
        //    responseFormat = _responseFormat;
        //}

        public async Task<string> GetApiToken(string userName, string password, string apiBaseUri)
        {

            const string AccessTokenKey = "access_token";

            using (HttpClient client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(apiBaseUri);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post,

                    new Uri(apiBaseUri + "/token")))
                {
                    request.Content = new FormUrlEncodedContent(new Dictionary<string, string>()
                         {
                        {"grant_type","password"},
                        {"username",userName},
                        {"password",password}
                        
                         });

                    //send request
                    HttpResponseMessage responseMessage = await client.SendAsync(request);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        JObject result = await responseMessage.Content.ReadAsAsync<JObject>();
                        var responseJson = await responseMessage.Content.ReadAsStringAsync();

                        var jObject = JObject.Parse(responseJson);
                        var token = (string)jObject[AccessTokenKey];

                        return token;
                    }
                    else
                        return "Incorrect Credentials";

                }
            }

        }
        public async Task<JObject> GetJObjectResponse(string token, string apiBaseUri, string requestPath, object modelObject)
        {
            using (HttpClient client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(apiBaseUri);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(apiBaseUri + requestPath)))
                {
                    request.Headers.Add("Authorization", "Bearer " + token);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage responseMessage = await client.SendAsync(request);

                    JObject result = await responseMessage.Content.ReadAsAsync<JObject>();
                    return result.ToObject<JObject>();
                }
            }
        }
        public async Task<JArray> GetJArrayResponse(string token, string apiBaseUri, string requestPath)
        {
            using (HttpClient client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(apiBaseUri);
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(apiBaseUri + requestPath)))
                {
                    request.Headers.Add("Authorization", "Bearer " + token);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(responseFormat.Json));

                    HttpResponseMessage responseMessage = await client.SendAsync(request);

                    JArray result = await responseMessage.Content.ReadAsAsync<JArray>();

                    return result;
                }
            }
        }
    }
}
