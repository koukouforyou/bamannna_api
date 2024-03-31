using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 季度枚举
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "季度", Name = "QuarterOfYear")]
    public enum QuarterOfYear
    {
        /// <summary>
        /// 第一季度
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "第一季度", Name = "FirstQuarter")]
        FirstQuarter = 1,

        /// <summary>
        /// 第二季度
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "第二季度", Name = "SecondQuarter")]
        SecondQuarter = 2,

        /// <summary>
        /// 第三季度
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "第三季度", Name = "ThirdQuarter")]
        ThirdQuarter = 4,

        /// <summary>
        /// 第四季度
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "第四季度", Name = "FourthQuarter")]
        FourthQuarter = 8
    }
}
