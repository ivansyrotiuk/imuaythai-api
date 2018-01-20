using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class CountriesDownloader: DataDownloader
    {
        public CountriesDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext): base(sourceContext, destinationContext)
        {
            
        }

        public override void Download()
        {
            var countries = SourceContext.Countries.ToList();
            countries.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.Countries);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.Countries.AddRange(countries);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}