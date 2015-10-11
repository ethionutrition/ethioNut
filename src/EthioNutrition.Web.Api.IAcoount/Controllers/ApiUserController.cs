using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using NHibernate;

namespace EthioNutrition.Web.Api.IAcoount.Controllers
{
    [Authorize]
    public class ApiUserController : ApiController
    {
        private ApplicationUserManager _userManager;
        private readonly ISession session;
        public ApiUserController()
        {
        }

        public ApiUserController(ApplicationUserManager userManager, ISession _session)
        {
            session = _session;
            _userManager = userManager;
        }

        // GET: api/User
        public async Task<EthioNutrition.Web.Api.Models.User> Get() 
        {
            var user = session.Get<EthioNutrition.Web.Api.Models.User>(User.Identity.GetUserId());
            //var name = User.Identity.Name;
            
            return (new EthioNutrition.Web.Api.Models.User{
                Email= user.Email,FirstName= user.FirstName,LastName=user.LastName
            });

           
         }
           
        }
    }
