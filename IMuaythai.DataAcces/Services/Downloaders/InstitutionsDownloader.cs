using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class InstitutionsDownloader : DataDownloader
    {
        public InstitutionsDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var institutions = SourceContext.Institutions.ToList();
            institutions.ForEach(NullReferencePropeties);

            var tableName = nameof(DestinationContext.Institutions);
            DeleteDataFromTable(tableName);
            SetInsertIdentityOn(tableName);
            DestinationContext.Institutions.AddRange(institutions);
            DestinationContext.SaveChanges();
            SetInsertIdentityOff(tableName);
        }
    }
}