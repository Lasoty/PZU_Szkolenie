using DeskBooking.Domain.Model;
using DeskBooking.Shared.ModelDto;
using DeskBooking.Shared.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DeskBooking.Server.Controllers
{
    public class LoginController : BaseApiController
    {
        private readonly IConfiguration configuration;
        private readonly SignInManager<User> signInManager;

        public LoginController(
            IConfiguration configuration,
            SignInManager<User> signInManager
            )
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

            if (!result.Succeeded)
                return BadRequest(new LoginResultDto {
                    Successful = false, Error = "Login lub hasło są nieprawidłowe." 
                });
            
            //TODO: Pobrać role użytkownika z bazy danych

            Claim[] claim = new[]
            {
                new Claim(ClaimTypes.Name, login.UserName),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(ClaimTypes.Role, "Administrator"),
            };

            JwtSecurityToken token = TokenUtilities.CreateToken(configuration, claim);
            LoginResultDto loginResult = new LoginResultDto
            {
                Successful = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return Ok(loginResult);
        }
    }
}
