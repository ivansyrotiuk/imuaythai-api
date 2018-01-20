using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class ContestTypePointsDownloader : DataDownloader
    {
        public ContestTypePointsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var contestTypePoints = SourceContext.ContestTypePoints.ToList();
            contestTypePoints.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.ContestTypePoints);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.ContestTypePoints.AddRange(contestTypePoints);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}