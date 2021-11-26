using DeskBooking.Shared.ModelDto;
using System.Threading.Tasks;

namespace DeskBooking.Services.ReservationServices
{
    public interface IReservationService
    {
        Task AddReservation(ReservationDto reservation);
    }
}