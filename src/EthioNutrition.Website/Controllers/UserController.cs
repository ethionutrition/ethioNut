using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Mvc;
using EthioNutrition.Web.Api.Models;
using System.Text;

namespace EthioNutrition.Website.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ErrorResult = "";
            HttpClient client = new HttpClient();
           // var webClient = new WebClient();
            const string creds = "webform@ethionutrition.com" + ":" + "webform@ethionutrition.com";
            var bcreds = Encoding.ASCII.GetBytes(creds);
            var base64Creds = Convert.ToBase64String(bcreds);
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + base64Creds);
            client.BaseAddress = new Uri("http://localhost:12423");
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/user").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Result = response.Content.ReadAsAsync<IEnumerable<User>>
                    ().Result;
            }
            else 
            {
                ViewBag.ErrorResult = "Error";
            }
            return View();
        }
    }
}
