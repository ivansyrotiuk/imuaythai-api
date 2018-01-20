using System.Linq;
using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public class UsersDownloader : DataDownloader
    {
        public UsersDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext) : base(sourceContext, destinationContext)
        {

        }

        public override void Download()
        {
            var users = SourceContext.Users.ToList();

            users.ForEach(item =>
            {
                NullReferencePropeties(item);
                item.Roles.Clear();
            });

            DeleteDataFromTable("AspNetUsers");
            DestinationContext.Users.AddRange(users);
            DestinationContext.SaveChanges();
        }
    }
}