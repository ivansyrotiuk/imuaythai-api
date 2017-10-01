using MuaythaiSportManagementSystemApi.Contests;
using MuaythaiSportManagementSystemApi.Dictionaries;
using MuaythaiSportManagementSystemApi.Models;
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
        public DateTime StartDate { get; set; }
        public FightStructureDto FightStructure { get; set; }

        public FightOverviewDto(Fight fight)
        {
            Contest = (ContestDto)fight.Contest;
            RedFighter = (FighterDto)fight.RedAthlete;
            BlueFighter = (FighterDto)fight.BlueAthlete;
            Winner = (FighterDto)fight.Winner;
            FightStructure = (FightStructureDto)fight.Structure;
        }

        public static explicit operator FightOverviewDto(Fight fight)
        {
            return new FightOverviewDto(fight);
        }
    }
}
