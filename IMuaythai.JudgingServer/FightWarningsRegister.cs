using System.Collections.Generic;
using IMuaythai.DataAccess.Models;

namespace IMuaythai.JudgingServer
{
    public interface IFightContext
    {
        bool CanStartNewRound();
        void ResetWarnings();
        void RegisterPoints(FightPoint points);

        int GetRoundNumber();
        void IncrementRoundNumber();
        void ResetRounds();
    }

    public class FightContext : IFightContext
    {
        private Dictionary<string, int> _fightWarnings;
        private int _roundNumber;

        public FightContext()
        {
            _fightWarnings = GetFightDictionary();
        }

        public void IncrementRoundNumber()
        {
            _roundNumber++;
        }

        public int GetRoundNumber()
        {
            return _roundNumber;
        }

        public void ResetRounds()
        {
            _roundNumber = 0;
        }

        public bool CanStartNewRound()
        {
            return _fightWarnings["Cautions"] <= 3 && _fightWarnings["Warnings"] <= 3 && _fightWarnings["KnockDown"] <= 3;
        }

        public void ResetWarnings()
        {
            _fightWarnings = GetFightDictionary();
        }

        public void RegisterPoints(FightPoint points)
        {
            _fightWarnings[nameof(points.Cautions)] += points.Cautions;

            _fightWarnings[nameof(points.Warnings)] += points.Warnings;

            _fightWarnings[nameof(points.KnockDown)] += points.KnockDown;

            _fightWarnings[nameof(points.J)] += points.J;

            _fightWarnings[nameof(points.X)] += points.X;

        }

        private Dictionary<string, int> GetFightDictionary()
        {
            return new Dictionary<string, int>
            {
                {"Cautions", 0},
                {"Warnings", 0},
                {"KnockDown", 0},
                {"J", 0},
                {"X", 0}
            };
        }
    }
}