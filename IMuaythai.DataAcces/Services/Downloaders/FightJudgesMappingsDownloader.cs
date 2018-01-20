using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class FightJudgesMappingsDownloader : DataDownloader
    {
        public FightJudgesMappingsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var fightJudgesMappings = SourceContext.FightJudgesMappings.ToList();
            fightJudgesMappings.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.FightJudgesMappings);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.FightJudgesMappings.AddRange(fightJudgesMappings);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}