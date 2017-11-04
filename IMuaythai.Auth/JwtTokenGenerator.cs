using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IMuaythai.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;

namespace IMuaythai.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>{
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("UserId", user.Id),
                        new Claim("InstitutionId", user.InstitutionId?.ToString() ?? string.Empty),
                        };


            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }

            claims.Add(new Claim("roles", string.Empty));
            claims.Add(new Claim("roles", string.Empty));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey123456789"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                                issuer: "http://localhost:5000",
                                audience: "http://localhost:5000",
                                claims: claims,
                                signingCredentials: creds
                                );
            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }
    }
}
