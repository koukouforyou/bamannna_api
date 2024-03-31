using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 枚举类型枚举
    /// </summary>
    [DataContract]
    [EnumType(DisplayName = "枚举类型", Name = "EnumType", EnumType = EnumType.Sequence)]
    //[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "9.10.9.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum EnumType
    {
        /// <summary>
        /// 顺序型
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "顺序型", Name = "Sequence", IsDefault = true)]
        Sequence = 1,

        /// <summary>
        /// 位域型
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "位域型", Name = "Flags", IsDefault = false)]
        Flags = 2,

    }
}
