using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Server.Controllers
{
    public class UserDataController : BaseApiController
    {
        public UserDataController()
        {

        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddUser(UserDataDto user)
        {
            return StatusCode(StatusCodes.Status418ImATeapot, "I'm teapot.");
        }
    }
}
