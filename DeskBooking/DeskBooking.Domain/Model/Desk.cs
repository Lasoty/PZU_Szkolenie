using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Domain.Model
{
    public class Desk : BaseEntity
    {
        public int Number { get; set; }

        public string RoomNumber { get; set; }

        public string Description { get; set; }

        public virtual Image ImageData { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
