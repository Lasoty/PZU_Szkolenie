using Blazorise;
using DeskBooking.Shared.ModelDto;
using DeskBooking.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeskBooking.Client.Services
{
    public class DeskDataProvider : IDeskDataProvider
    {
        private readonly HttpClient httpClient;
        private readonly INotificationService notificationService;

        public DeskDataProvider(HttpClient httpClient, INotificationService notificationService)
        {
            this.httpClient = httpClient;
            this.notificationService = notificationService;
        }

        public async Task<ICollection<DeskDto>> GetFreeDesks(DateTime from, DateTime to)
        {
            ICollection<DeskDto> result = null;
            FreeDesksRequest request = new()
            { 
                From = from,
                To = to
            };

            HttpResponseMessage response = await httpClient.PostAsJsonAsync("Desks/FreeDesks", request);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<ICollection<DeskDto>>(content);
            }
            else
            {
                await notificationService.Error("Błąd pobierania danych z serwera.", "Błąd danych");
            }

            if (result == null || !result.Any())
                await notificationService.Error("Brak biurek w bazie danych.", "Błąd danych");

            return result;
        }
    }
}
