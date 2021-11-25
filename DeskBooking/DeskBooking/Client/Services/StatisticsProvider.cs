using Blazorise;
using DeskBooking.Shared.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DeskBooking.Client.Services
{
    public class StatisticsProvider : IStatisticsProvider
    {
        private readonly HttpClient httpClient;
        private readonly INotificationService notificationService;

        public StatisticsProvider(
            HttpClient httpClient,
            INotificationService notificationService
            )
        {
            this.httpClient = httpClient;
            this.notificationService = notificationService;
        }

        public async Task<ICollection<DeskReservationDto>> GetReservationsInLastMonth()
        {
            try
            {
                ICollection<DeskReservationDto> data = await httpClient.
                        GetFromJsonAsync<ICollection<DeskReservationDto>>("Statistics/ReservationsInLastMonth");
                return data;
            }
            catch (Exception)
            {
                await notificationService.Error("Nie można pobrać danych statystycznych rezerwacji.",
                    "Błąd pobierania danych.");
            }

            return null;
        }
    }
}
