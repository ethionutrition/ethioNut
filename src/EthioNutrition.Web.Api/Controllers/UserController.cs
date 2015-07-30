using EthioNutrition.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EthioNutrition.Web.Api.Controllers
{
    public class UserController : ApiController
    {
        //Constructor
        public UserController()
        {

        }
        public User Get(Guid id)
        {
            return null;
        }

        public HttpResponseMessage Post(HttpRequestMessage request, User user)
        {
            //var response = request.CreateResponse(HttpStatusCode.Created, newUser);
            //response.Headers.Add("Location", Href);
            return null;
        }
        public HttpResponseMessage Delete(Guid id)
        {
            return null;
        }
    }
}
