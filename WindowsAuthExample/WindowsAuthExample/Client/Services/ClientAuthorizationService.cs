using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using WindowsAuthExample.Shared.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace WindowsAuthExample.Client.Services
{
    public class ClientAuthorizationService : AuthenticationStateProvider
    {
        private const string AuthenticationType = "BackEnd";
        private readonly HttpClient httpClient;
        public ClientAuthorizationService(HttpClient httpClient)
        {
            if (httpClient == null) throw new ArgumentNullException(nameof(httpClient));
            this.httpClient = httpClient;
        }
        public string ApiUriGetAuthorizedUser { get; set; }

        public string ApiUriSignIn { get; set; }

        public string ApiUriSignOut { get; set; }

        public AuthorizedUser AuthorizedUser { get; private set; } = new AuthorizedUser();
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsPrincipal user;
            if (!string.IsNullOrEmpty(ApiUriGetAuthorizedUser))
                AuthorizedUser = await httpClient.GetFromJsonAsync<AuthorizedUser>(ApiUriGetAuthorizedUser);
            if (string.IsNullOrEmpty(AuthorizedUser.Name))
            {
                user = new ClaimsPrincipal();
            }
            else
            {
                var identity = new ClaimsIdentity(CreateClaims(AuthorizedUser), AuthenticationType);
                user = new ClaimsPrincipal(identity);
            }
            return new AuthenticationState(user);
        }

        private static IEnumerable<Claim> CreateClaims(AuthorizedUser authorizedUser)
        {
            yield return new Claim(ClaimTypes.Name, authorizedUser.Name);

            var roles = authorizedUser.Roles?.Split(',') ?? new string[0];
            foreach (var role in roles)
                yield return new Claim(ClaimTypes.Role, role.Trim());
        }
    }
}
