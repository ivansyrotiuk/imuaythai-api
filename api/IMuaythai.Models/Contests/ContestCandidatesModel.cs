using System.Collections.Generic;
using IMuaythai.Models.Users;

namespace IMuaythai.Models.Contests
{
    public class ContestCandidatesModel
    {
        public List<UserModel> DirectCandidates { get; set; }
        public List<UserModel> CountryCandidates { get; set; }
        public List<UserModel> ContinentCandidates { get; set; }
        public List<UserModel> AllCandidates { get; set; }
    }
}
