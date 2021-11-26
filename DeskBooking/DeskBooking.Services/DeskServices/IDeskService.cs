using DeskBooking.Shared.ModelDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeskBooking.Services.DeskServices
{
    public interface IDeskService
    {
        Task<ICollection<DeskDto>> GetFreeDesks(DateTime from, DateTime to);
    }
}