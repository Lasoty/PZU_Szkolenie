using System;

namespace DeskBooking.Shared.ModelDto
{
    public class ReservationDto
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int DeskId { get; set; }

        public int UserId { get; set; }
    }
}
