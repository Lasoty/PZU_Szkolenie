using System;

namespace DeskBooking.Shared.Requests
{
    public class FreeDesksRequest
    {
        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
