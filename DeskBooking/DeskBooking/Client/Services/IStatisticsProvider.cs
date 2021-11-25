using DeskBooking.Shared.ModelDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeskBooking.Client.Services
{
    public interface IStatisticsProvider
    {
        Task<ICollection<DeskReservationDto>> GetReservationsInLastMonth();
    }
}