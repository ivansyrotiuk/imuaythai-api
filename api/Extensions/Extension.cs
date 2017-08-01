using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MuaythaiSportManagementSystemApi.Extensions
{
    public static class Extension
    {
        public static long ToUnixDateTime(this DateTime dateTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (dateTime.ToUniversalTime() - epoch).TotalSeconds.ToLong();
        }

        public static int ToInt(this object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            if (obj is int)
            {
                return (int)obj;
            }

            int result = 0;
            if (int.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            decimal resultDecimal = 0;
            if (decimal.TryParse(obj.ToString(), out resultDecimal))
            {
                return (int)resultDecimal;
            }

            return 0;
        }

        public static long ToLong(this object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            if (obj is long)
            {
                return (long)obj;
            }

            long result = 0;
            if (long.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            decimal resultDecimal = 0;
            if (decimal.TryParse(obj.ToString(), out resultDecimal))
            {
                return (long)resultDecimal;
            }

            return 0;
        }

        public static int? ToNullableInt(this object obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (obj is int?)
            {
                return (int?)obj;
            }

            int result;
            if (int.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            decimal resultDecimal;
            if (decimal.TryParse(obj.ToString(), out resultDecimal))
            {
                return (int)resultDecimal;
            }

            return null;
        }

        public static decimal ToDecimal(this object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            decimal result = 0;

            if (decimal.TryParse(obj.ToString(), out result))
            {
                return result;
            }

            try
            {
                return decimal.Parse(obj.ToString().Replace(",", "."), CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine($"Error of convering to decimal. Input = {obj}");
                return 0;
            }
        }

        public static DateTime ToDateTimeOrNow(this object row)
        {
            if (row == null)
            {
                return DateTime.Now;
            }

            DateTime result;
            return DateTime.TryParse(row.ToString(), out result) ? result : DateTime.Now;
        }
    }
}
