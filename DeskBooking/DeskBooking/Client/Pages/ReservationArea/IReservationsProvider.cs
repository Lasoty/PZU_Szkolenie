using DeskBooking.Shared.ModelDto;
using System.Threading.Tasks;

namespace DeskBooking.Client.Pages.ReservationArea
{
    public interface IReservationsProvider
    {
        Task<bool> SaveReservation(ReservationDto reservation);
    }
}