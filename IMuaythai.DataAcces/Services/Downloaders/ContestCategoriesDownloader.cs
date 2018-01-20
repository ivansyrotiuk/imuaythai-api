using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class ContestCategoriesDownloader : DataDownloader
    {
        public ContestCategoriesDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var contestCategories = SourceContext.ContestCategories.Take(100).ToList();
            contestCategories.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.ContestCategories);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.ContestCategories.AddRange(contestCategories);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}