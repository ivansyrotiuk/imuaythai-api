using MuaythaiSportManagementSystemApi.Contests;
using MuaythaiSportManagementSystemApi.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MuaythaiSportManagementSystemApi.Fights.Overview.DTO
{
    public class FightOverviewDto
    {
        public ContestDto Contest { get; set; }
        public FighterDto RedFighter { get; set; }
        public FighterDto BlueFighter{ get; set; }
        public FighterDto Winner { get; set; }

    }
}
