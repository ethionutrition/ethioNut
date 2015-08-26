using System;
using System.Net;
using System.Text;
using NUnit.Framework;

namespace EthioNutrition.SmokeTest
{
    [TestFixture]
    public class ApiTests
    {
        public const string ApiUrlRoot = "http://localhost:12423/api";

       
        [Test]
        public void GetAllUsers()
        {
            var client = CreateAdminWebClient();
            var response = client.DownloadString(ApiUrlRoot + "/users");

            Console.Write(response);
        }

        [Test]
        public void AddNewUser()
        {
            var client = CreateWebClientToCreateUser();

            const string url = ApiUrlRoot + "/User";
            const string method = "POST";
            const string newUser =
                "{\"Email\":\"jania@ethionutrition.com\",\"Password\":\"jania1234\",\"FirstName\":\"jania\",\"LastName\":\"Anbesaw\"}";

            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString(url, method, newUser);

            Console.Write(response);
        }

        private WebClient CreateWebClientToCreateUser()
        {
            var webClient = new WebClient();

            const string creds = "webform@ethioNutrition.com" + ":" + "webform@ethionutrition.com";
            var bcreds = Encoding.ASCII.GetBytes(creds);
            var base64Creds = Convert.ToBase64String(bcreds);
            webClient.Headers.Add("Authorization", "Basic " + base64Creds); // d2ViZm9ybUBldGhpb251dHJpdGlvbi5jb206d2ViZm9ybUBldGhpb251dHJpdGlvbi5jb20=
            return webClient;
        }
        private WebClient CreateAdminWebClient()
        {
            var webClient = new WebClient();

            const string creds = "jbob" + ":" + "jbob12345";// Admin User
            var bcreds = Encoding.ASCII.GetBytes(creds);
            var base64Creds = Convert.ToBase64String(bcreds);
            webClient.Headers.Add("Authorization", "Basic " + base64Creds); // amJvYjpqYm9iMTIzNDU= 
            return webClient;
        }
    }
}
