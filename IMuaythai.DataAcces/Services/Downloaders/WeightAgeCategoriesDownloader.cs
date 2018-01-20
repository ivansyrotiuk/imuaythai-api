using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class WeightAgeCategoriesDownloader : DataDownloader
    {
        public WeightAgeCategoriesDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var weightAgeCategories = SourceContext.WeightAgeCategories.ToList();
            weightAgeCategories.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.WeightAgeCategories);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.WeightAgeCategories.AddRange(weightAgeCategories);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}