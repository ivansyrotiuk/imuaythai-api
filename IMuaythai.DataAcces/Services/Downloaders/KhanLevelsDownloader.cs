using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class KhanLevelsDownloader : DataDownloader
    {
        public KhanLevelsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var khanLevels = SourceContext.KhanLevels.ToList();
            khanLevels.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.KhanLevels);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.KhanLevels.AddRange(khanLevels);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}