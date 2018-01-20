using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class ContestTypesDownloader : DataDownloader
    {
        public ContestTypesDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var contestTypes = SourceContext.ContestTypes.ToList();
            contestTypes.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.ContestTypes);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.ContestTypes.AddRange(contestTypes);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}