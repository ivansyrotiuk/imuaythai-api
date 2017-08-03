using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Contests
{
    public class ContestCandidatesDto
    {
        public List<UserDto> DirectCandidates { get; set; }
        public List<UserDto> CountryCandidates { get; set; }
        public List<UserDto> ContinentCandidates { get; set; }
        public List<UserDto> AllCandidates { get; set; }
    }
}
