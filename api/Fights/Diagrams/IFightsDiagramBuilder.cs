using System.Collections.Generic;
using MuaythaiSportManagementSystemApi.Fights.FightsStructure;
using MuaythaiSportManagementSystemApi.Models;

namespace MuaythaiSportManagementSystemApi.Fights
{
    public interface IFightsDiagramBuilder
    {
        List<Game> GenerateFightDiagram(List<Fight> fights);
        string ToJson();
    }
}