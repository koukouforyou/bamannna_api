using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 时间单位枚举
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "时间单位", Name = "TimeUnit")]
    public enum TimeUnit
    {
        /// <summary>
        /// 毫秒
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "毫秒", Name = "Millisecond")]
        Millisecond = 1,

        /// <summary>
        /// 秒
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "秒", Name = "Second")]
        Second = 2,

        /// <summary>
        /// 分
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "分", Name = "Minute")]
        Minute = 4,

        /// <summary>
        /// 小时
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "小时", Name = "Hour")]
        Hour = 8,

        /// <summary>
        /// 天
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "天", Name = "Day", IsDefault = true)]
        Day = 16,

        /// <summary>
        /// 周
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "周", Name = "Week")]
        Week = 32,

        /// <summary>
        /// 月
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "月", Name = "Month")]
        Month = 64,

        /// <summary>
        /// 季度
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "季度", Name = "Quarter")]
        Quarter = 128,

        /// <summary>
        /// 年
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "年", Name = "Year")]
        Year = 256
    }
}
