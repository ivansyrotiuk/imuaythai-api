using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class UserRolesDownloader : DataDownloader
    {
        public UserRolesDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var userRoles = SourceContext.UserRoles.ToList();
            userRoles.ForEach(NullReferencePropeties);

            DeleteDataFromTable("AspNetUserRoles");
            DestinationContext.UserRoles.AddRange(userRoles);
            DestinationContext.SaveChanges();
        }
    }
}