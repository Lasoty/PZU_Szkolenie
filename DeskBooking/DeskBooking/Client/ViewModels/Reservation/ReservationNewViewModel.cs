using DeskBooking.Shared.ModelDto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeskBooking.Client.ViewModels.Reservation
{
    public class ReservationNewViewModel
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public virtual ObservableCollection<DeskDto> DeskList { get; set; }

        public int SelectedDesk { get; set; }
    }
}
