using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Shared.ModelDto
{
    public class DeskReservationDto
    {
        public int ReservationId { get; set; }
        public int DeskId { get; set; }
        public int DeskNumber { get; set; }
        public DateTime ReservationStartAt { get; set; }
        public DateTime ReservationEndAt { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public bool IsCanceled { get; set; }
        public string CancelReason { get; set; }
    }
}
