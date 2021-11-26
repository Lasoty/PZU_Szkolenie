using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DeskBooking.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthService(
            HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider
            )
        {
            this.httpClient = httpClient;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Register(RegisterUserDto registerModel)
        {
            var response = await httpClient.PostAsJsonAsync("Accounts", registerModel);
            return response.IsSuccessStatusCode;
        }
    }
}
