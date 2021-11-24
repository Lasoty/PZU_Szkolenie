namespace DeskBooking.Domain.Model
{
    public class Image : BaseEntity
    {
        public string Name { get; set; }

        public byte ImageData { get; set; }
    }
}