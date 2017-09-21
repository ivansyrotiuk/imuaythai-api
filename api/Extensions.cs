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

    public static class EntitiesExtensions
    {
        public static void DeepCopyTo(this object source, object target)
        {
            if (source.GetType() != target.GetType())
            {
                throw new ArgumentException("Source and destination objects must be an instance of the same type");
            }

            var properties = source.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                try
                {
                    var value = property.GetValue(source);
                    property.SetValue(target, value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
    }

}
