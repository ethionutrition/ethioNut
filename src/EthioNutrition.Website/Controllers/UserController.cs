using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using EthioNutrition.Web.Common;
using EthioNutrition.Web.Api.Models;

namespace EthioNutrition.Website.Controllers
{
    public class UserController : Controller
    {
        private readonly IWebApi apiToken = new WebApi();

        //public UserController()
        //{

        //}
        //public UserController(IWebApi _apiToken)
        //{
        //    apiToken = _apiToken;
        //}
        public async Task<ActionResult> Index()
        {
            const string userName = "test@test.com";
            const string password = "P@ss0rd1";
            const string apiBaseUri = "http://localhost:1457";
            const string apiGetValuesPath = "/api/values";
          
            var token = await apiToken.GetApiToken(userName, password, apiBaseUri);

            var response = await apiToken.GetJArrayResponse(token, apiBaseUri, apiGetValuesPath);
            //var _Userresponse = await apiToken.GetRequest(token, apiBaseUri, "/api/user",new EthioNutrition.Web.Api.Models.User());
           
                ViewData["Result"] = response;
            
                return View();
           
        }
    }
}
