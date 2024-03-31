using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 工作日类型
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "工作日类型", Name = "WeekDayType")]
    public enum DayOfWorkType
    {
        /// <summary>
        /// 星期天
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期天", Name = "Sunday")]
        Sunday = 1,

        /// <summary>
        /// 星期一
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期一", Name = "Monday")]
        Monday = 2,


        /// <summary>
        /// 星期二
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期二", Name = "Tuesday")]
        Tuesday = 4,


        /// <summary>
        /// 星期三
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期三", Name = "Wednesday")]
        Wednesday = 8,


        /// <summary>
        /// 星期四
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期四", Name = "Thursday")]
        Thursday = 16,


        /// <summary>
        /// 星期五
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期五", Name = "Friday")]
        Friday = 32,


        /// <summary>
        /// 星期六
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "星期六", Name = "Saturday")]
        Saturday = 64,

        /// <summary>
        /// 工作日
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "工作日", Name = "WorkDay")]
        WorkDay = 128,

        /// <summary>
        /// 休息日
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "休息日", Name = "DayOff")]
        DayOff = 256,

        /// <summary>
        /// 天
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "天", Name = "Day")]
        Day = 512,
    }
}
