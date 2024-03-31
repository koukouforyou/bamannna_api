using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 实体关系类型
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "实体关系类型", Name = "RelationshipType")]
    public enum RelationshipType
    {

        /// <summary>
        /// 外键
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "外键", Name = "ForeignKey", IsDefault = true)]
        ForeignKey = 1,

        /// <summary>
        /// 关联
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "关联", Name = "Relation", IsDefault = false)]
        Relation = 2,

        /// <summary>
        /// 唯一关联
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "唯一关联", Name = "Unique", IsDefault = false)]
        Unique = 3,
    }
}
