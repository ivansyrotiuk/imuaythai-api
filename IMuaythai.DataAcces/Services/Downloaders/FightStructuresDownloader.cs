using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class FightStructuresDownloader : DataDownloader
    {
        public FightStructuresDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var fightStructures = SourceContext.FightStructures.ToList();
            fightStructures.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.FightStructures);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.FightStructures.AddRange(fightStructures);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}