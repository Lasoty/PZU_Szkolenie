using DeskBooking.Domain.Data;
using DeskBooking.Domain.Model;
using DeskBooking.Domain.Repositories;
using DeskBooking.Services.StatisticsServices;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Server.Controllers
{
    [Authorize]
    public class StatisticsController : BaseApiController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(
            IStatisticsService statisticsService
            )
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ReservationsInLastMonth()
        {
            var result = await statisticsService.GetDeskReservationDtoAsync();
            return Ok(result);
        }
    }
}
