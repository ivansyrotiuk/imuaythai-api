using System.Collections.Generic;
using IMuaythai.DataAccess.Models;
using IMuaythai.Fights.Diagrams.FightsStructure;

namespace IMuaythai.Fights.Diagrams
{
    public interface IFightsDiagramBuilder
    {
        List<Game> GenerateFightDiagram(List<Fight> fights);
        string ToJson();
    }
}