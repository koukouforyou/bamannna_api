using System.Runtime.Serialization;
using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 业务需求级别
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "业务需求级别", Name = "AttributeRequireLevelType")]
    public enum BusinessRequireLevel
    {
        /// <summary>
        /// 无约束
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "无约束", Name = "NonRequire")]
        NonRequire = 1,

        /// <summary>
        /// 业务推荐
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "业务推荐", Name = "BusinessRequire")]
        BusinessRequire = 2,

        /// <summary>
        /// 业务必需
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "业务必需", Name = "Require")]
        Require = 3,
    }
}
