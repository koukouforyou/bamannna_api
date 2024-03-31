using System;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 属性类型
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "属性类型", Name = "FieldType")]
    public enum FieldType
    {
        /// <summary>
        /// 自建字段
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "自建字段", Name = "Customer")]
        Customer = 1,

        /// <summary>
        /// 默认字段
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "默认字段", Name = "Default")]
        Default = 2,

        /// <summary>
        /// 审计字段
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "审计字段", Name = "Audit")]
        Audit = 3,
    }

    /// <summary>
    /// 数据类型
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "数据类型", Name = "DataType")]
    public enum DataType
    {
        /// <summary>
        /// 字符串
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "字符串", Name = "String")]
        String = 1,


        /// <summary>
        /// 整型
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "整型", Name = "Int")]
        Int = 2,

        /// <summary>
        /// 日期/时间
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "日期/时间", Name = "DateTime")]
        DateTime = 3,

        /// <summary>
        /// 唯一标识
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "唯一标识", Name = "Guid")]
        Guid = 4,

        /// <summary>
        /// 枚举
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "枚举", Name = "Enum")]
        Enum = 5,

        /// <summary>
        /// 长整型
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "长整型", Name = "Long")]
        Long = 6,

        /// <summary>
        /// 精确值
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "精确值", Name = "Decimal")]
        Decimal = 7,

        /// <summary>
        /// 浮点数
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "浮点数", Name = "Float")]
        Float = 8,

        /// <summary>
        /// 自动编号
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "自动编号", Name = "Identity")]
        Identity = 9,

        /// <summary>
        /// 文本
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "文本", Name = "Text")]
        Text = 10,

        /// <summary>
        /// 布尔
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "布尔", Name = "Boolean")]
        Boolean = 11,
    }
}
