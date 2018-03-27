using System.Linq;
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
        void ResetState();
        FightState GetFightState();
        int GetFightId();
        void InitState(int id);
        void StartRound();
        void EndRound();
        void PauseRound();
        void ResumeRound();

    }

    public class FightContext : IFightContext
    {
        private readonly FightState _fightState;

        public FightContext(ApplicationDbContext context)
        {
            _fightState = new FightState(context);
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

        public void StartRound()
        {
            _fightState.Round++;
            _fightState.SetMode("fight");
            _fightState.Started = true;
            _fightState.Paused = false;
            _fightState.StartTimer();
        }

        public void EndRound()
        {
            _fightState.SetMode("pause");
            _fightState.Started = false;
            _fightState.StartTimer();
        }

        public void PauseRound()
        {
            _fightState.Paused = true;
            _fightState.PauseTimer();
        }

        public void ResumeRound()
        {
            _fightState.Paused = false;
            _fightState.StartTimer();
        }

        public bool CanStartNewRound()
        {
            var fightWarnings = _fightState.GetWarnings();
            if (fightWarnings.Count == 0)
                return true;
            return fightWarnings.Sum(f => f.Cautions) <= 3 && fightWarnings.Sum(f => f.Warnings) <= 3 && fightWarnings.Sum(f => f.KnockDown) <= 3;
        }
    }
}