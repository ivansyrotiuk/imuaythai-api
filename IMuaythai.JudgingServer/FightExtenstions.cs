using IMuaythai.DataAccess.Models;

namespace IMuaythai.JudgingServer
{
    static class FightExtenstions
    {
        public static void AssignPrevFightWinner(this Fight nextFight, string athleteId)
        {
            if (nextFight == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(nextFight.RedAthleteId))
            {
                nextFight.RedAthleteId = athleteId;
            }
            else
            {
                nextFight.BlueAthleteId = athleteId;
            }

        }
    }
}