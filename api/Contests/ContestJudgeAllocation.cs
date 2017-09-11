using MuaythaiSportManagementSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Contests
{
    public class ContestJudgeAllocation
    {
        public ContestJudgeType? JudgeType { get; set; }
        public int RequestId { get; set; }
    }
}
