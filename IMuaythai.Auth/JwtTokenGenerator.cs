using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using IMuaythai.DataAccess.Models;
using Microsoft.IdentityModel.Tokens;

namespace IMuaythai.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private const string DatetimeFormat = "yyyyMMddHHmmss";

        private readonly JwtConfiguration _configuration;

        public JwtTokenGenerator(JwtConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateToken(ApplicationUser user, IList<string> roles)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(user));

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(DatetimeFormat)),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration.Issuer),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Surname),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration.Issuer),
                new Claim(ImuaythaiJwtRegisteredClaimNames.UserId, user.Id),
                new Claim(ImuaythaiJwtRegisteredClaimNames.InstitutionId, Convert.ToString(user.InstitutionId)),
            };
            
           

            var roleClaims = CreateRoleClaims(roles);
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration.Issuer,
                audience: _configuration.Audience,
                claims: claims,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static List<Claim> CreateRoleClaims(IList<string> roles)
        {
            var claims = roles.Select(role => new Claim(ImuaythaiJwtRegisteredClaimNames.Roles, role)).ToList();

            //Hack: it makes the roles claim to be an array
            var emptyRoleClaims = Enumerable.Repeat(new Claim(ImuaythaiJwtRegisteredClaimNames.Roles, string.Empty), 2);
            claims.AddRange(emptyRoleClaims);
            return claims;
        }
    }

    public struct ImuaythaiJwtRegisteredClaimNames
    {
        public const string UserId = "UserId";
        public const string InstitutionId = "InstitutionId";
        public const string Roles = "roles";
    }
}
