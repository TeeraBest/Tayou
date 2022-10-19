using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utac.DataAccessLogic.Helpers
{
    public static class DateHelper
    {
        public static string ChangeFromDateToString(DateTime? date, string format)
        {
            if (date == null)
            {
                return null;
            }
            return date.Value.ToString(format, CultureInfo.InvariantCulture);
        }
        public static DateTime? ChangeFromStringToDateSimple(this string date, string[] format = null, bool fromXml = false)
        {
            if (string.IsNullOrEmpty(date))
            {
                return null;
            }
            
            string userDateTimeFormat = !fromXml ? "MM/dd/yyyy" : "yyyy-MM-dd";//SessionAuthen.Data.FormatDate
            format = format ?? new string[] {
                userDateTimeFormat,
                $"{userDateTimeFormat} HH:mm:ss",
                $"{userDateTimeFormat} HH:mm",
                $"{userDateTimeFormat} hh:mm:ss tt"
            };

            if (format != null && format.Length == 1)
            {
                format= new string[] {
                    format[0],
                userDateTimeFormat,
                $"{userDateTimeFormat} HH:mm:ss",
                $"{userDateTimeFormat} HH:mm",
                $"{userDateTimeFormat} hh:mm:ss tt"
            };
            }

            DateTime dt;
            if (DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public static DateTimeOffset? ChangeFromDateTimeLocalToDateTimeUTC(this string date, string[] format = null)
        {
            DateTime newDateTime = ChangeFromStringToDateSimple(date, format).Value;
            if (string.IsNullOrEmpty(newDateTime.ToString())) return null;

            DateTimeOffset d = new DateTimeOffset((Convert.ToDateTime(newDateTime)));
            d = new DateTimeOffset(d.UtcDateTime, TimeSpan.Zero);
            return d;
        }

        public static DateTimeOffset? ConvertToDateTimeUTC(this DateTime? date, int dateTimeOffset)
        {
            var dateTimeUtc = date.GetValueOrDefault().AddMinutes(dateTimeOffset);
            var UniversalDateTimeCreated = new DateTimeOffset(dateTimeUtc, TimeSpan.Zero);

            return UniversalDateTimeCreated;
        }
    }
}
