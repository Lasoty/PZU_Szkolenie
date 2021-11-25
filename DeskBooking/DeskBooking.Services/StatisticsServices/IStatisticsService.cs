using DeskBooking.Shared.ModelDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeskBooking.Services.StatisticsServices
{
    public interface IStatisticsService
    {
        Task<ICollection<DeskReservationDto>> GetDeskReservationDtoAsync();
    }
}