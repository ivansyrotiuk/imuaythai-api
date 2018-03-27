using System;
using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.UnitTests
{
    public class Mocks
    {
        public ApplicationDbContext GetDefaultDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            
            var contextMock = new ApplicationDbContext(options);
            return contextMock;
        }
    }
}