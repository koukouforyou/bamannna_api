using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using Bamanna.DouDian.Infrastructure.Types;
using Newtonsoft.Json;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 枚举类型自定义属性：用于enum类型
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Enum, Inherited = false, AllowMultiple = false)]
    public class EnumTypeAttribute : AttributeBase
    {
        /// <summary>
        /// 父ID
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string ParentID { get; set; }

        /// <summary>
        /// 枚举类型：顺序枚举，位域枚举
        /// </summary>
        [DataMember]
        [XmlAttribute]
        [JsonIgnore]
        public EnumType EnumType { get; set; }
    }
}
