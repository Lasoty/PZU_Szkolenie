using DeskBooking.Shared.ModelDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeskBooking.Client.Services
{
    public interface IDeskDataProvider
    {
        Task<ICollection<DeskDto>> GetFreeDesks(DateTime from, DateTime to);
    }
}