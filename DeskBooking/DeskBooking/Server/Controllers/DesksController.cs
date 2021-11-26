using DeskBooking.Services.DeskServices;
using DeskBooking.Shared.ModelDto;
using DeskBooking.Shared.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Server.Controllers
{
    public class DesksController : BaseApiController
    {
        private readonly IDeskService deskService;

        public DesksController(
            IDeskService deskService
            )
        {
            this.deskService = deskService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> FreeDesks(FreeDesksRequest request)
        {
            ICollection<DeskDto> result = await deskService.GetFreeDesks(request.From, request.To);

            if (result.Any())
                return Ok(result);

            return NotFound();
        }
    }
}
