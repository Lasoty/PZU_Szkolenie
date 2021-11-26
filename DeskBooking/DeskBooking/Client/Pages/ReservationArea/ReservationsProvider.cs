using DeskBooking.Shared.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.ReservationArea
{
    public class ReservationsProvider : IReservationsProvider
    {
        private readonly HttpClient httpClient;

        public ReservationsProvider(
            HttpClient httpClient
            )
        {
            this.httpClient = httpClient;
        }

        public async Task<bool> SaveReservation(ReservationDto reservation)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("Reservations", reservation);
            return response.IsSuccessStatusCode;
        }
    }
}
