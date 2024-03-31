using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 字节单位
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "字节单位", Name = "ByteSizeType")]
    public enum ByteSizeType
    {
        /// <summary>
        /// GB
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "GB", Name = "GB")]
        GB = 0x40000000,

        /// <summary>
        /// MB
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "MB", Name = "MB")]
        MB = 0x100000,

        /// <summary>
        /// KB
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "KB", Name = "KB")]
        KB = 0x400,
    }
}
