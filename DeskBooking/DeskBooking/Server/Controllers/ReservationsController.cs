using DeskBooking.Services.ReservationServices;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Server.Controllers
{
    public class ReservationsController : BaseApiController
    {
        private readonly IReservationService reservationService;

        public ReservationsController(
            IReservationService reservationService
            )
        {
            this.reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReservationDto reservation)
        {
            await reservationService.AddReservation(reservation);
            return Ok();
        }
    }
}
