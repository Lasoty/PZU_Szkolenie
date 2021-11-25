using DeskBooking.Domain.Model;
using DeskBooking.Domain.Repositories;
using DeskBooking.Shared.ModelDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Services.StatisticsServices
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository<Reservation> reservationRepository;

        public StatisticsService(
            IRepository<Reservation> reservationRepository
            )
        {
            this.reservationRepository = reservationRepository;
        }

        public async Task<ICollection<DeskReservationDto>> GetDeskReservationDtoAsync()
        {
            DateTime today = DateTime.Now.Date;

            ICollection<DeskReservationDto> reservations = await reservationRepository.Find(r =>
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

            return reservations;
        }
    }
}
