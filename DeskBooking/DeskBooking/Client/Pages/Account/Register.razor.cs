using Blazorise;
using DeskBooking.Client.Services;
using DeskBooking.Client.ViewModels.Account;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.Account
{
    public partial class Register : ComponentBase
    {
        private bool termsAndConditions; //TODO: przenieść do view modelu

        [Inject]
        INotificationService viewNotifier { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        [Inject]
        AuthenticationStateProvider authStateProvider { get; set; }

        [Inject]
        IAuthService AuthService { get; set; }

        [CascadingParameter]
        Task<AuthenticationState> authenticationStateTask { get; set; }

        Validations registrationValidations;
        RegisterViewModel vm = new RegisterViewModel();

        public Register()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            ClaimsPrincipal user = (await authenticationStateTask).User;

            if (user.Identity.IsAuthenticated)
                navigationManager.NavigateTo("/");
        }

        protected async Task RegisterSubmit()
        {
            //if (! await registrationValidations.ValidateAll())
            //{
            //    return;
            //}
            //await registrationValidations.ClearAll();

            try
            {
                bool result = await AuthService.Register(new RegisterUserDto
                {
                    Email = vm.Email,
                    FirstName = vm.FullName.Split(' ')[0],
                    LastName = vm.FullName.Split(' ').Last(),
                    UserName = vm.UserName,
                    Password = vm.Password
                });

                if (result)
                    navigationManager.NavigateTo("/");
                else
                    await viewNotifier.Error("Błąd rejestracji użytkownika", "Błąd");
            }
            catch (Exception ex)
            {
                await viewNotifier.Error("Wystąpił nieprzewidziany wyjątek", "Błąd");
            }
        }
    }

}
