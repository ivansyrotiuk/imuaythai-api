using System;
using System.Reflection;

namespace MuaythaiSportManagementSystemApi
{

    public static class EntitiesExtensions
    {
        public static void DeepCopyTo(this object source, object target)
        {
            if (source.GetType() != target.GetType())
            {
                throw new ArgumentException("Source and destination objects must be an instance of the same type");
            }

            var properties = source.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                try
                {
                    var value = property.GetValue(source);
                    property.SetValue(target, value);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

        }
    }

}