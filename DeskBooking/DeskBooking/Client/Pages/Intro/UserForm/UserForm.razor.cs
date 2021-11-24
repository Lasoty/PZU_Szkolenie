using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.Intro.UserForm
{
    public partial class UserForm
    {
        string firstName = string.Empty;
        string lastName = string.Empty;
        int age = 0;

        [Inject]
        public HttpClient HttpClient { get; set; }

        bool isEditHidden = false;
        bool isCardHidden = true;

        public void ShowInfo()
        {
            isEditHidden = true;
            isCardHidden = false;
        }

        public async Task SaveUser()
        {
            UserDataDto userData = new UserDataDto
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            HttpResponseMessage message = await HttpClient.PostAsJsonAsync("UserData/AddUser", userData);
            if (message.IsSuccessStatusCode)
                await ShowMessage();

            if ((int)message.StatusCode == 418)
                await ShowMessage();
        }

        private async Task ShowMessage()
        {
            
        }
    }
}
