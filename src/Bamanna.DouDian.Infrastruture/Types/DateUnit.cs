using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 日期单位枚举
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "日期单位枚举", Name = "DateUnit")]
    public enum DateUnit
    {
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
