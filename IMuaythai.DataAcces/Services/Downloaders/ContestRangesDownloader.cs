using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class ContestRangesDownloader : DataDownloader
    {
        public ContestRangesDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var contestRanges = SourceContext.ContestRanges.ToList();
            contestRanges.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.ContestRanges);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.ContestRanges.AddRange(contestRanges);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}