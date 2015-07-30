using EthioNutrition.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EthioNutrition.Common;

namespace EthioNutrition.Web.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IDateTime _datetime;
        //Constructor
        public UserController(IDateTime datetime)
        {
            _datetime = datetime;
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
