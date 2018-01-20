using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class SuspensionsDownloader : DataDownloader
    {
        public SuspensionsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var suspensions = SourceContext.Suspensions.ToList();
            suspensions.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.Suspensions);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.Suspensions.AddRange(suspensions);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}