using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class ContestsDownloader : DataDownloader
    {
        public ContestsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var contests = SourceContext.Contests.ToList();
            contests.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.Contests);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.Contests.AddRange(contests);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}