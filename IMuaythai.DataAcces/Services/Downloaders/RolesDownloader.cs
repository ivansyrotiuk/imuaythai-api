using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class RolesDownloader : DataDownloader
    {
        public RolesDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var roles = SourceContext.Roles.ToList();
            roles.ForEach(NullReferencePropeties);

            DeleteDataFromTable("AspNetRoles");
            DestinationContext.Roles.AddRange(roles);
            DestinationContext.SaveChanges();
        }
    }
}