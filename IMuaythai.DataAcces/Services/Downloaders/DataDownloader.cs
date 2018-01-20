using System;
using IMuaythai.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace IMuaythai.DataAccess.Services.Downloaders
{
    public abstract class DataDownloader
    {
        protected readonly ApplicationDbContext SourceContext;
        protected readonly ApplicationDbContext DestinationContext;

        protected DataDownloader(ApplicationDbContext sourceContext, ApplicationDbContext destinationContext)
        {
            SourceContext = sourceContext;
            DestinationContext = destinationContext;
        }

        public abstract void Download();

        protected void DeleteDataFromTable(string tableName)
        {
            var rawSqlString = $"DELETE FROM [dbo].[{tableName}]";
            DestinationContext.Database.ExecuteSqlCommand(rawSqlString);
        }

        protected void SetInsertIdentityOn(string tableName)
        {
            var rawSqlString = $"SET IDENTITY_INSERT [dbo].[{tableName}] ON";
            DestinationContext.Database.ExecuteSqlCommand(rawSqlString);
        }

        protected void SetInsertIdentityOff(string tableName)
        {
            var rawSqlString = $"SET IDENTITY_INSERT [dbo].[{tableName}] OFF";
            DestinationContext.Database.ExecuteSqlCommand(rawSqlString);
        }

        protected void NullReferencePropeties(object obj)
        {
            Type type = obj.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                if (propertyType.IsValueType || propertyType == typeof(string) || propertyType.IsNotPublic)
                {
                    continue;
                }

                try
                {
                    property.SetValue(obj, null);
                }
                catch
                {
                    //Ignore
                }
            }

        }
    }
}
