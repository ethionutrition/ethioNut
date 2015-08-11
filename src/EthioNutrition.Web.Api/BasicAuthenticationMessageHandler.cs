using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using NHibernate;
using EthioNutrition.Web.Common.Security;
using EthioNutrition.Data.Models;

namespace EthioNutrition.Web.Api
{
    public class BasicAuthenticationMessageHandler: DelegatingHandler
    {
        public const string BasicScheme = "Basic";
        public const string ChallengeAuthenticationHeaderName = "WWW-Authenticate";
        public const char AuthorizationHeaderSeparator = ':';

        private readonly IMembershipInfoProvider _membershipAdapter;
        private readonly ISessionFactory _sessionFactory;

        public BasicAuthenticationMessageHandler(IMembershipInfoProvider membershipAdapter, ISessionFactory sessionFactory)
        {
            _membershipAdapter = membershipAdapter;
            _sessionFactory = sessionFactory;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var authHeader = request.Headers.Authorization;
            if (authHeader == null)
            {
                return CreateUnauthorizedResponse();
            }

            if (authHeader.Scheme != BasicScheme)
            {
                return CreateUnauthorizedResponse();
            }

            var encodedCredentials = authHeader.Parameter;
            var credentialBytes = Convert.FromBase64String(encodedCredentials);
            var credentials = Encoding.ASCII.GetString(credentialBytes);
            var credentialParts = credentials.Split(AuthorizationHeaderSeparator);

            if (credentialParts.Length != 2)
            {
                return CreateUnauthorizedResponse();
            }

            var email = credentialParts[0].Trim();
            var password = credentialParts[1].Trim();

            if (!_membershipAdapter.ValidateUser(email, password))
            {
                return CreateUnauthorizedResponse();
            }

            SetPrincipal(email);

            return base.SendAsync(request, cancellationToken);
        }

        private void SetPrincipal(string email)
        {
            var roles = _membershipAdapter.GetRolesForUser(email);
            var user = _membershipAdapter.GetUser(email);

            User modelUser;
            using (var session = _sessionFactory.OpenSession())
            {
                modelUser = session.Get<User>(user.UserId);
            }

            var identity = CreateIdentity(user.Email, modelUser);

            var principal = new GenericPrincipal(identity, roles);
            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
        private GenericIdentity CreateIdentity(string email, User modelUser)
        {
            var identity = new GenericIdentity(email, BasicScheme);
            identity.AddClaim(new Claim(ClaimTypes.Sid, modelUser.UserId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, modelUser.FirstName));
            identity.AddClaim(new Claim(ClaimTypes.Surname, modelUser.LastName));
            identity.AddClaim(new Claim(ClaimTypes.Email, modelUser.Email));
            identity.AddClaim(new Claim(ClaimTypes.Name, modelUser.Email));
            return identity;
        }
        private Task<HttpResponseMessage> CreateUnauthorizedResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            //tells the calling browser or other application that you are expecting basic authentication credentials—and you didn’t get them.
            response.Headers.Add(ChallengeAuthenticationHeaderName, BasicScheme);

            var taskCompletionSource = new TaskCompletionSource<HttpResponseMessage>();
            taskCompletionSource.SetResult(response);
            return taskCompletionSource.Task;
        }
    }
}