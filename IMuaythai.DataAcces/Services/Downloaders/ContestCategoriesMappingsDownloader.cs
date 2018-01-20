using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class ContestCategoriesMappingsDownloader : DataDownloader
    {
        public ContestCategoriesMappingsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var contestCategoriesMappings = SourceContext.ContestCategoriesMappings.ToList();
            contestCategoriesMappings.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.ContestCategoriesMappings);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.ContestCategoriesMappings.AddRange(contestCategoriesMappings);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}