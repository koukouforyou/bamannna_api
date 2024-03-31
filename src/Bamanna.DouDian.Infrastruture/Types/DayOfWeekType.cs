using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 星期枚举
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "星期", Name = "WeekDayType")]
    public enum DayOfWeekType
    {
        /// <summary>
        /// 星期天
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期天", Name = "Sunday", EnumFactor = 0)]
        Sunday = 1,

        /// <summary>
        /// 星期一
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期一", Name = "Monday", EnumFactor = 1)]
        Monday = 2,


        /// <summary>
        /// 星期二
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期二", Name = "Tuesday", EnumFactor = 2)]
        Tuesday = 4,


        /// <summary>
        /// 星期三
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期三", Name = "Wednesday", EnumFactor = 3)]
        Wednesday = 8,


        /// <summary>
        /// 星期四
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期四", Name = "Thursday", EnumFactor = 4)]
        Thursday = 16,


        /// <summary>
        /// 星期五
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期五", Name = "Friday", EnumFactor = 5)]
        Friday = 32,


        /// <summary>
        /// 星期六
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期六", Name = "Saturday", EnumFactor = 6)]
        Saturday = 64,
    }
}
