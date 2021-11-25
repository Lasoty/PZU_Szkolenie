using System;
using System.Collections.Generic;

namespace DeskBooking.Client.ViewModels.Reservation
{
    public class ReservationNewViewModel
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public IDictionary<int, string> DeskList { get; set; }

        public int SelectedDesk { get; set; }
    }
}
