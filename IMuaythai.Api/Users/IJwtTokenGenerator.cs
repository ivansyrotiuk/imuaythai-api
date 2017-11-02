using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Api.Users
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user, IList<string> roles);
    }
}