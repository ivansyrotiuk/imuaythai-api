using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class ContestRingsDownloader : DataDownloader
    {
        public ContestRingsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var contestRings = SourceContext.ContestRings.ToList();
            contestRings.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.ContestRings);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.ContestRings.AddRange(contestRings);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}