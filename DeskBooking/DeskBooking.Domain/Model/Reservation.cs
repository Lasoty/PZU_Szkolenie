using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Domain.Model
{
    public class Reservation : BaseEntity
    {
        public DateTime Start { get; set; }
        
        public DateTime End { get; set; }

        public bool IsCanceled { get; set; }

        public string CancelReason { get; set; }

        public int DeskId { get; set; }
        public Desk Desk { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
