using Blazorise;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.Account
{
    public partial class Login : ComponentBase
    {
        public Login()
        {

        }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        [Inject]
        INotificationService viewNotifier { get; set; }


        protected override async Task OnInitializedAsync()
        {
        }

        protected void Register()
        {
            NavigationManager.NavigateTo("/account/register");
        }

        protected async Task SubmitLogin()
        {

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
