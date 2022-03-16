using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsAuthExample.Client.Services;

namespace WindowsAuthExample.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<ClientAuthorizationService>(CreateAuthorizationService);
            builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ClientAuthorizationService>());
            builder.Services.AddOptions();

            builder.Services.AddHttpClient("WindowsAuthExample.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WindowsAuthExample.ServerAPI"));
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }

        private static ClientAuthorizationService CreateAuthorizationService(IServiceProvider serviceProvider)
        {
            var httpClient = serviceProvider.GetRequiredService<HttpClient>();
            var service = new ClientAuthorizationService(httpClient)
            {
                ApiUriGetAuthorizedUser = "User/GetUser",

                ApiUriSignIn = "AzureADB2C/Account/SignIn",
                ApiUriSignOut = "AzureADB2C/Account/SignOut",
            };
            return service;
        }
    }
}
