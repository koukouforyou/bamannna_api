using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrastructure.Extentions
{
    public static class DatetimeExtention
    {
        public static int Quarter(this DateTime datetime)
        {
            return datetime.Month / 4 + 1;
        }

        public static string EnMonth(this DateTime datetime)
        {
            switch (datetime.Month)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                case 12:
                    return "Dec";
                default:
                    return "";
            }
        }

        public static long GetTimeStamp(this DateTime datetime, bool IsMill = true)
        {
            TimeSpan ts = datetime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (!IsMill)
            {
                return Convert.ToInt64(ts.TotalSeconds);
            }
            else
            {
                return Convert.ToInt64(ts.TotalMilliseconds);
            }
        }

        public static DateTime GetDateTimeByLong(this long timestamp, bool isMill = true)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTime.UtcNow.Kind);
            if (!isMill)
            {
                return start.AddSeconds(timestamp).ToLocalTime();
            }
            else
            {
                return start.AddMilliseconds(timestamp).ToLocalTime();
            }
        }
    }
}