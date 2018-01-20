using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IMuaythai.DataAccess.Contexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json") 
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }

    public class ApplicationMainDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("MainDatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }

    public interface IContextFactoryFacade
    {
        ApplicationDbContext CreateDbContext();
        ApplicationDbContext CreateMainDbContext();
    }

    public class ContextFactoryFacade : IContextFactoryFacade
    {
        private readonly IDesignTimeDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly IDesignTimeDbContextFactory<ApplicationDbContext> _mainDbContextFactory;

        public ContextFactoryFacade()
        {
            _dbContextFactory = new ApplicationDbContextFactory();
            _mainDbContextFactory = new ApplicationMainDbContextFactory();
        }

        public ApplicationDbContext CreateDbContext()
        {
            return _dbContextFactory.CreateDbContext(new string[]{});
        }

        public ApplicationDbContext CreateMainDbContext()
        {
            return _mainDbContextFactory.CreateDbContext(new string[]{});
        }
    }
}