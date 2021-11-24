namespace DeskBooking.Domain.Model
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public virtual Image ImageData { get; set; }
    }
}