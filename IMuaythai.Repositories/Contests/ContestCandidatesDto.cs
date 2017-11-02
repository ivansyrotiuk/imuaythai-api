using System.Collections.Generic;
using IMuaythai.Repositories.Users;

namespace IMuaythai.Repositories.Contests
{
    public class ContestCandidatesDto
    {
        public List<UserDto> DirectCandidates { get; set; }
        public List<UserDto> CountryCandidates { get; set; }
        public List<UserDto> ContinentCandidates { get; set; }
        public List<UserDto> AllCandidates { get; set; }
    }
}
