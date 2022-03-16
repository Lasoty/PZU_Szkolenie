using Blazorise;
using DeskBooking.Client.Services;
using DeskBooking.Client.ViewModels.Account;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.Account
{
    public partial class Login : ComponentBase
    {
        LoginViewModel vm = new LoginViewModel();

        public Login()
        {

        }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        INotificationService viewNotifier { get; set; }

        [Inject]
        IAuthService AuthService { get; set; }


        protected override async Task OnInitializedAsync()
        {
        }

        protected void Register()
        {
            NavigationManager.NavigateTo("/account/register");
        }

        protected async Task SubmitLogin()
        {
            LoginDto loginDto = new()
            {
                UserName = vm.UserName,
                Password = vm.Password
            };

            bool result = await AuthService.Login(loginDto);

            if (result)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                await viewNotifier.Error("Błąd Logowania");
            }
        }

        protected async Task SubmiGoogletLogin()
        {
            await viewNotifier.Error("Logowanie za pomocą Google nie jest jeszcze obsługiwane.", "Brak obsługi");
        }

        protected async Task SubmiFacebooktLogin()
        {
            await viewNotifier.Error("Logowanie za pomocą Facebooka nie jest jeszcze obsługiwane.", "Brak obsługi");
        }

        protected async Task ForgotPassword()
        {

        }

    }
}
