using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MuaythaiSportManagementSystemApi.Controllers
{
    public class TokenProvider
    {
        public static string GenerateToken(int id)
        {

            var claims = new Claim[]{
                new Claim(JwtRegisteredClaimNames.Sub, "test"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            };

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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
