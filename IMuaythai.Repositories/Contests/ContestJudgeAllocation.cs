using IMuaythai.DataAccess.Models;

namespace IMuaythai.Repositories.Contests
{
    public class ContestJudgeAllocation
    {
        public ContestJudgeType? JudgeType { get; set; }
        public int RequestId { get; set; }
    }
}
