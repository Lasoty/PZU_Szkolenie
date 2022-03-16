using Blazored.LocalStorage;
using DeskBooking.Client.ViewModels.Account;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeskBooking.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorage;

        public AuthService(
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage
            )
        {
            this.httpClient = httpClient;
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorage = localStorage;
        }

        public async Task<bool> Login(LoginDto loginModel)
        {
            var response = await httpClient.PostAsJsonAsync("Login", loginModel);
            var loginResult = JsonSerializer.Deserialize<LoginResultDto>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

            if (!response.IsSuccessStatusCode)
            {
                //TODO: Toast dla błędu
                return false;
            }

            await localStorage.SetItemAsync("authToken", loginResult.Token);
            ((ApiAuthenticationStateProvider)authenticationStateProvider).MarkUserAsAuthenticated(loginModel.UserName);
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", loginResult.Token);

            return true;
        }

        public async Task<bool> Register(RegisterUserDto registerModel)
        {
            var response = await httpClient.PostAsJsonAsync("Accounts", registerModel);
            return response.IsSuccessStatusCode;
        }
    }
}
