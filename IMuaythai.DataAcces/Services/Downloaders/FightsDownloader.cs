using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class FightsDownloader : DataDownloader
    {
        public FightsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var fights = SourceContext.Fights.ToList();
            fights.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.Fights);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.Fights.AddRange(fights);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}