using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Fights.JudgeSelectors
{
    public interface IAppropriateJudgeSelector
    {
        string SelectJudgeForFight(Fight fight, List<Fight> contestFights, List<ContestRequest> judgeRequests);
    }
}
