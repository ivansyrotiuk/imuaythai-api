using Microsoft.AspNetCore.Identity;
using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi
{

    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            var userIdClaim = principal.Claims.FirstOrDefault(c => c.Type == "UserId");

            return userIdClaim?.Value;
        }
    }

}
