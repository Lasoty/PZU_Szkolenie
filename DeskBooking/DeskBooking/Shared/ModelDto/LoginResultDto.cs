namespace DeskBooking.Shared.ModelDto
{
    public class LoginResultDto
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
