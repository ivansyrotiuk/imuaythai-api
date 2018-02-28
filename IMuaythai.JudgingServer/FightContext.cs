using IMuaythai.DataAccess.Contexts;
using IMuaythai.DataAccess.Models;
using IMuaythai.JudgingServer.State;

namespace IMuaythai.JudgingServer
{
    public interface IFightContext
    {
        bool CanStartNewRound();
        void RegisterPoints(FightPoint points);

        int GetRoundNumber();
        void IncrementRoundNumber();
        void ResetState();
        FightState GetFightState();
        int GetFightId();
        void InitState(int id);

    }

    public class FightContext : IFightContext
    {
        private readonly FightState _fightState;

        public FightContext(ApplicationDbContext context)
        {
            _fightState = new FightState(context);
        }

        public void IncrementRoundNumber()
        {
            _fightState.Round++;
        }

        public void ResetState()
        {
            _fightState.Reset();
        }

        public void RegisterPoints(FightPoint points)
        {
            _fightState.SetPoints(points);
        }

        public int GetRoundNumber()
        {
            return _fightState.Round;
        }

        public FightState GetFightState()
        {
            return _fightState;
        }

        public int GetFightId()
        {
            return _fightState.Id;
        }

        public void InitState(int id)
        {
            _fightState.Initialize(id);
        }

        public bool CanStartNewRound()
        {
            var fightWarnings = _fightState.GetWarnings();
            return fightWarnings["Cautions"] <= 3 && fightWarnings["Warnings"] <= 3 && fightWarnings["KnockDown"] <= 3;
        }
    }
}