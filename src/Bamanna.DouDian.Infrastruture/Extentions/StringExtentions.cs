using System;


namespace Bamanna.DouDian.Infrastructure.Extentions
{
    /// <summary>
    /// 字符串扩展方法
    /// </summary>
    public static class StringExtentions
    {
        /// <summary>
        /// 转化成易读的字符串(英文）
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isFirstUpper"></param>
        /// <returns></returns>
        public static string ToFriendlyString(this string str, bool isFirstUpper)
        {
            return "";
        }

        /// <summary>
        /// 转化成PascalCase字符串(英文）
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        public static string ToPascalCase(this string str,char separator)
        {
            string re = string.Empty;
            string[] strs = str.Split(separator);
            foreach (var item in strs)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                if (re.Length > 0)
                {
                    re += separator;
                }

                re += $"{item.Substring(0, 1).ToUpper()}{item.Substring(1)}";
            }

            return re;
        }

        /// <summary>
        /// 转化成CamelCase字符串(英文）
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCamelCaseName(this string str)
        {
            int index = 0;
            foreach (char c in str)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    index++;
                }
                else
                {
                    break;
                }
            }
            if (index < 1)
            {
                return str;
            }
            return string.Format("{0}{1}", str.Substring(0, index).ToLower(), str.Substring(index));
        }

        /// <summary>
        /// 是否无效字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInvalid(this string str)
        {
            return (str.IsNull() || str.Trim() == string.Empty);
        }

        /// <summary>
        /// 转化成Int,转化失败返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ParseInt(this string str)
        {
            try
            {
                return Convert.ToInt32(str.Trim());
            }
            catch
            {
                return 0;
            }

        }

        /// <summary>
        /// 转化成double
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ParseDouble(this string str)
        {
            try
            {
                return Convert.ToDouble(str.Trim());
            }
            catch
            {
                return 0.0d;
            }
        }

        /// <summary>
        /// 转化成Bool
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool ParseBool(this string str)
        {
            try
            {
                return Convert.ToBoolean(str.Trim().ParseInt());
            }
            catch
            {
                return Boolean.Parse(str.Trim());
            }
        }

        /// <summary>
        /// 转化成Guid，转化失败返回Guid.Empty
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Guid ParseGuid(this string str)
        {
            try
            {
                return new Guid(str.Trim());
            }
            catch
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// 转化成时间类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ParseDatetime(this string str)
        {
            try
            {
                return Convert.ToDateTime(str.Trim());
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
    }
}
