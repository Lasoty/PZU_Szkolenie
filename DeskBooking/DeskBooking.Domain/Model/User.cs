using Microsoft.AspNetCore.Identity;
using System;

namespace DeskBooking.Domain.Model
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual Image ImageData { get; set; }
    }
}