using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 大小写类型枚举
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "大小写类型", Name = "CaseType")]
    public enum CaseType
    {
        /// <summary>
        /// 首字母都大写
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "首字母都大写", Name = "Pascal", Memo = "将标识符的首字母和后面连接的每个单词的首字母都大写。例如：BackColor")]
        Pascal = 1,

        /// <summary>
        /// 大小写混合
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "大小写混合", Name = "Camel", Memo = "标识符的首字母小写，而每个后面连接的单词的首字母都大写。例如：backColor")]
        Camel = 2,

        /// <summary>
        /// 小写
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "小写", Name = "Lower", Memo = "标识符中的所有字母都小写。例如：backcolor")]
        Lower = 4,

        /// <summary>
        /// 大写
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "大写", Name = "Upper", Memo = "标识符中的所有字母都大写。例如：BACKCOLOR")]
        Upper = 8,
    }
}
