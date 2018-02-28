using System.Collections.Generic;
using System.Linq;
using IMuaythai.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace IMuaythai.UnitTests
{
    public static class Mocks
    {
        public static DbSet<T> CreateDbSetMock<T>(IEnumerable<T> persistedData = null) where T : class
        {
            var dbSetMock = Substitute.For<DbSet<T>, IQueryable<T>>();

            if (persistedData != null)
            {
                var data = persistedData.AsQueryable();
                ((IQueryable<T>) dbSetMock).Provider.Returns(data.Provider);
                ((IQueryable<T>) dbSetMock).Expression.Returns(data.Expression);
                ((IQueryable<T>) dbSetMock).ElementType.Returns(data.ElementType);
                ((IQueryable<T>) dbSetMock).GetEnumerator().Returns(data.GetEnumerator());
            }

            return dbSetMock;
        }
    }
}