using DeskBooking.Domain.Model;
using DeskBooking.Domain.Repositories;
using DeskBooking.Services.Common;
using DeskBooking.Shared.ModelDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Services.DeskServices
{
    public class DeskService : IDeskService
    {
        private readonly IRepository<Desk> deskRepository;

        public DeskService(
            IRepository<Desk> deskRepository
            )
        {
            this.deskRepository = deskRepository;
        }

        public async Task<ICollection<DeskDto>> GetFreeDesks(DateTime from, DateTime to)
        {
            Range<DateTime> askRange = new Range<DateTime>(from, to);
            var desks = await deskRepository.GetAll()
                .Include(x => x.Reservations.Where(r => (r.Start >= from || r.End >= from) && (r.Start <= to || r.End <= to)))
                .ToListAsync();

            foreach (var item in desks)
            {
                bool tmp = item.Reservations.Any(r => new Range<DateTime>(r.Start, r.End).IsOverlapped(askRange));
            }

            List<DeskDto> result = desks.Where(x => !x.Reservations.Any(r => new Range<DateTime>(r.Start, r.End).IsOverlapped(askRange)))
            .Select(x => new DeskDto
            {
                Id = x.Id,
                Number = x.Number,
                RoomNumber = x.RoomNumber,
                Description = x.Description
            })
            .ToList();

            return result;
        }
    }
}
