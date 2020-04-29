using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace apbd_cw6.Handlers
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {


        public BasicAuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
                               ) : base(options, logger, encoder, clock)
        {

        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing authorization");

            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

            var credBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credBytes).Split(":"); //login:Haslo
            if (credentials.Length!= 2) return AuthenticateResult.Fail("wrong header");


            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,"1"),
                new Claim(ClaimTypes.Name, "pawel"),
                new Claim(ClaimTypes.Role, "student"),
                new Claim(ClaimTypes.Role, "admin")
            };

            var idnenty = new ClaimsIdentity(claims, Scheme.Name);
            var prinicpal = new ClaimsPrincipal(idnenty);
            var ticket = new AuthenticationTicket(prinicpal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }

}
