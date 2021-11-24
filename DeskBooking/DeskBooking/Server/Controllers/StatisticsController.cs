using DeskBooking.Domain.Data;
using DeskBooking.Domain.Model;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Server.Controllers
{
    public class StatisticsController : BaseApiController
    {
        private readonly ApplicationDbContext dbContext;

        public StatisticsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ReservationsInLastMonth()
        {
            DateTime today = DateTime.Now.Date;

            List<DeskReservationDto> reservations = await dbContext.Reservations.Where(r =>
                   (r.Start > today.AddDays(-30) && r.Start <= today)
                || (r.End > today.AddDays(-30) && r.End <= today))
                .Include(r => r.Desk)
                .Include(r => r.User)
                .AsNoTracking()
                .Select(r => new DeskReservationDto
                {
                    DeskId = r.DeskId,
                    ReservationId = r.Id,
                    DeskNumber = r.Desk.Number,
                    IsCanceled = r.IsCanceled,
                    CancelReason = r.CancelReason,
                    ReservationStartAt = r.Start,
                    ReservationEndAt = r.End,
                    UserFirstName = r.User.FirstName,
                    UserLastName = r.User.LastName
                })
                .ToListAsync();

            return Ok(reservations);
        }
    }
}
