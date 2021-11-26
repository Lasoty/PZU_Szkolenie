using DeskBooking.Domain.Model;
using DeskBooking.Shared.ModelDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskBooking.Server.Controllers
{
    public class AccountsController : BaseApiController
    {
        private readonly UserManager<User> userManager;

        public AccountsController(
            UserManager<User> userManager
            )
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserDto model)
        {
            User user = new User
            {
                UserName = model.UserName,
                NormalizedUserName = model.UserName.ToUpper(),
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return Ok();

            return BadRequest();
        }
    }
}
