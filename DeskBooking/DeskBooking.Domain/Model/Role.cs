using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooking.Domain.Model
{
    public class Role : IdentityRole<Guid>
    {
        public virtual ICollection<User> Users { get; set; }
    }
}
