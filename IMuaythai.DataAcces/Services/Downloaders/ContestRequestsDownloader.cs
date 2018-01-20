using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class ContestRequestsDownloader : DataDownloader
    {
        public ContestRequestsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var contestRequests = SourceContext.ContestRequests.ToList();
            contestRequests.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.ContestRequests);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.ContestRequests.AddRange(contestRequests);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}