using DeskBooking.Client.ViewModels.Account;
using DeskBooking.Shared.ModelDto;
using System.Threading.Tasks;

namespace DeskBooking.Client.Services
{
    public interface IAuthService
    {
        Task<bool> Register(RegisterUserDto registerModel);
        Task<bool> Login(LoginDto vm);
    }
}