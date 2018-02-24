using IMuaythai.DataAccess.Contexts;

namespace IMuaythai.DataAccess
{
    public static class DbContextExtenstions
    { 
        public static void BeginTransaction(this ApplicationDbContext context)
        {
            context.Database.BeginTransaction();
        }

        public static void CommitTransaction(this ApplicationDbContext context)
        {
            context.Database.CommitTransaction();
        }

        public static void RollbackTransaction(this ApplicationDbContext context)
        {
            context.Database.RollbackTransaction();
        }
    }
}
