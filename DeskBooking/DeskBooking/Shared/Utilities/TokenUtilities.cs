using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeskBooking.Shared.Utilities
{
    public static class TokenUtilities
    {
        public static JwtSecurityToken CreateToken(IConfiguration configuration, Claim[] claims)
        {
            SymmetricSecurityKey key = 
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime expiry = DateTime.Now.AddDays(7);

            JwtSecurityToken token = new JwtSecurityToken(
                configuration["JwtIssuer"],
                configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );
            return token;
        }
    }
}
