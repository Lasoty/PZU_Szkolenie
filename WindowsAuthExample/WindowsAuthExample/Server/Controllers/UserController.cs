using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Threading.Tasks;
using WindowsAuthExample.Shared.Model;

namespace WindowsAuthExample.Server.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser()
        {
            AuthorizedUser result = new()
            {
                Name = HttpContext?.User?.Identity.Name ?? string.Empty
            };

            return Ok(result);
        }
    }
}
