using System.Collections.Generic;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Repositories;

namespace IMuaythai.Api.Fights
{
    public interface IFighterMovingService
    {
        Task<List<Fight>> MoveFighterToFight(FighterMoving fighterMoving);
    }

    public class FighterMovingService : IFighterMovingService
    {
        private readonly IFightsRepository _repository;

        public FighterMovingService(IFightsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Fight>> MoveFighterToFight(FighterMoving fighterMoving)
        {
            Fight sourceFight = await _repository.Get(fighterMoving.SourceFightId);
            Fight targetFight = fighterMoving.SourceFightId != fighterMoving.TargetFightId ? 
                await _repository.Get(fighterMoving.TargetFightId) : sourceFight;

            string sourceRedFighterId = sourceFight.RedAthleteId;
            string sourceBlueFighterId = sourceFight.BlueAthleteId;


            if (targetFight.RedAthleteId == fighterMoving.TargetFighterId)
            {
                targetFight.RedAthleteId = fighterMoving.SourceFighterId;
            }

            if (targetFight.BlueAthleteId == fighterMoving.TargetFighterId)
            {
                targetFight.BlueAthleteId = fighterMoving.SourceFighterId;
            }

            if (sourceRedFighterId == fighterMoving.SourceFighterId)
            {
                sourceFight.RedAthleteId = fighterMoving.TargetFighterId;
            }

            if (sourceBlueFighterId == fighterMoving.SourceFighterId)
            {
                sourceFight.BlueAthleteId = fighterMoving.TargetFighterId;
            }
 
            var fights = new List<Fight> { sourceFight, targetFight };
            await _repository.SaveFights(fights);
            
            return fights;
        }
    }
}
