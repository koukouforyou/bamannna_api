using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Bamanna.DouDian.Infrastructure.Utilities
{
    public static class DateTimeUnixTimeUtility
    {
        /// <summary>
        /// 日期转换成unix时间戳，
        /// </summary>
        /// <param name="dateTime">dateTime应传入utc的时间</param>
        /// <returns></returns>
        public static long DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, dateTime.Kind);
            return Convert.ToInt64((dateTime - start).TotalSeconds);
        }

        /// <summary>
        /// 获取当前时间的时间戳
        /// </summary>
        /// <param name="bflag">true为秒,false为毫秒</param>
        /// <returns></returns>
        public static long DateTimeNowToUnixTimestamp(bool bflag)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (bflag)
                return Convert.ToInt64(ts.TotalSeconds);
            else
                return Convert.ToInt64(ts.TotalMilliseconds);
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="bflag">true为秒,false为毫秒</param>
        /// <returns></returns>
        public static long DateTimeTo13UnixTimestamp(DateTime dateTime, bool bflag)
        {
            TimeSpan ts = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            if (bflag)
                return Convert.ToInt64(ts.TotalSeconds);
            else
                return Convert.ToInt64(ts.TotalMilliseconds);
        }

        /// <summary>
        /// unix时间戳转换成日期
        /// </summary>
        /// <param name="unixTimeStamp">时间戳（秒）</param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(this DateTime target, long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, target.Kind);
            return start.AddSeconds(timestamp);
        }

        /// <summary>
        /// unix时间戳转换成日期（秒）
        /// </summary>
        /// <param name="unixTimeStamp">时间戳（秒）</param>
        /// <returns></returns>
        public static DateTime UnixSecondTimestampToDateTime(long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTime.UtcNow.Kind);
            return start.AddSeconds(timestamp).ToLocalTime();
        }

        /// <summary>
        /// unix时间戳转换成日期（毫秒）
        /// </summary>
        /// <param name="unixTimeStamp">时间戳（毫秒）</param>
        /// <returns></returns>
        public static DateTime UnixMilliTimestampToDateTime(long timestamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTime.UtcNow.Kind);
            return start.AddMilliseconds(timestamp).ToLocalTime();
        }

        /// <summary>
        /// unix时间戳转换成日期（支持秒和毫秒）
        /// </summary>
        /// <param name="timestamp">时间戳（支持秒和毫秒）</param>
        /// <returns></returns>
        public static DateTime UnixTimestampToDateTime(long? timestamp)
        {
            var result = new DateTime(1970, 1, 1);
            if (timestamp.HasValue)
            {
                if (timestamp.Value.ToString().Length>12&&timestamp.Value.ToString().LastIndexOf("000") > 0)
                {
                    result = UnixMilliTimestampToDateTime(timestamp.Value);
                }
                else
                {
                    try
                    {
                        result = UnixSecondTimestampToDateTime(timestamp.Value);
                    }
                    catch
                    {
                        result = UnixMilliTimestampToDateTime(timestamp.Value);
                    }
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// String转换日期
        /// </summary>
        /// <param name="time">时间字符串</param>
        /// <param name="format">字符串格式</param>
        /// <returns></returns>
        public static DateTime StringFormatToDateTime(string time, string format)
        {
            DateTimeFormatInfo dtFormat = new DateTimeFormatInfo();
            dtFormat.ShortDatePattern = format;
            return System.Convert.ToDateTime(time, dtFormat);
        }
    }
}
