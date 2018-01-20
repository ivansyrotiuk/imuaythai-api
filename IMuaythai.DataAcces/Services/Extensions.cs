using System;

namespace IMuaythai.DataAccess.Services
{
    internal static class Extensions
    {
        public static T NullReferencePropeties<T>(this T obj)
        {
            var type = obj.GetType();
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
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            return obj;
        }
    }
}