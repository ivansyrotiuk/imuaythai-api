using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class RoundsDownloader : DataDownloader
    {
        public RoundsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var rounds = SourceContext.Rounds.ToList();
            rounds.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.Rounds);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.Rounds.AddRange(rounds);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}