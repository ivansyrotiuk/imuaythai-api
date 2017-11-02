using System.Collections.Generic;
using IMuaythai.Api.Fights.Diagrams.FightsStructure;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.Api.Fights.Diagrams
{
    public interface IFightsDiagramBuilder
    {
        List<Game> GenerateFightDiagram(List<Fight> fights);
        string ToJson();
    }
}