using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Bamanna.DouDian.Infrastructure.Types;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 数据反射属性自定义属性
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class StaticEntityPropertyAttribute : ModelPropertyAttribute
    {
        /// <summary>
        /// 是否主键
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public bool IsPK { get; set; }

        /// <summary>
        /// 是否自增列
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public bool IsIdentity { get; set; }

        /// <summary>
        /// 是否时间戳
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public bool IsTimestamp { get; set; }

        /// <summary>
        /// 可否为空
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public bool CanNull { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public DynamicDataType DataType { get; set; }

        /// <summary>
        /// 最大长度
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public int MaxLength { get; set; }
    }
}
