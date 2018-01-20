using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class SuspensionTypesDownloader : DataDownloader
    {
        public SuspensionTypesDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var suspensionTypes = SourceContext.SuspensionTypes.ToList();
            suspensionTypes.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.SuspensionTypes);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.SuspensionTypes.AddRange(suspensionTypes);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}