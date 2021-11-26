using Blazorise;
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

        [CascadingParameter]
        Task<AuthenticationState> authenticationStateTask { get; set; }

        Validations registrationValidations;

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

        }
    }

}
