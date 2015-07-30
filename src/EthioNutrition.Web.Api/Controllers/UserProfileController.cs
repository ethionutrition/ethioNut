using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EthioNutrition.Web.Api.Models;

namespace EthioNutrition.Web.Api.Controllers
{
    public class UserProfileController : ApiController
    {
        //Constructor
        public UserProfileController()
        {

        }
        public UserProfile Get(Guid UserId)
        {
            return null;
        }
        public HttpResponseMessage Put(HttpRequestMessage request, UserProfile profile, Guid UserId)
        {
            return null;
        }

    }
}
