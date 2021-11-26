using DeskBooking.Domain.Model;
using DeskBooking.Domain.Repositories;
using DeskBooking.Shared.ModelDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> reservationRepository;
        private readonly IRepository<Desk> deskRepository;

        public ReservationService(
            IRepository<Reservation> reservationRepository,
            IRepository<Desk> deskRepository
            )
        {
            this.reservationRepository = reservationRepository;
            this.deskRepository = deskRepository;
        }

        public async Task AddReservation(ReservationDto reservation)
        {
            if (IsValid(reservation))
            {
                Reservation reservationEntity = new()
                { 
                    DeskId = reservation.DeskId,
                    UserId = reservation.UserId,
                    Start = reservation.Start,
                    End = reservation.End
                };

                await reservationRepository.AddAsync(reservationEntity);
            }
            else
            {
                throw new InvalidOperationException("Nieprawidłowe dane rezerwacji.");
            }
        }

        private bool IsValid(ReservationDto reservation)
        {
            bool result = true;

            if (reservation.Start < reservation.End) result = false;
            if (!deskRepository.GetAll().Any(x => x.Id == reservation.DeskId)) result = false;

            return result;
        }
    }
}
