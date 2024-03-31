using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 枚举值自定义属性
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class EnumValueAttribute : AttributeBase
    {   
        /// <summary>
        /// 枚举值
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public int Value { get; set; }

        /// <summary>
        /// 枚举类型
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string EnumID { get; set; }
       
        /// <summary>
        /// 枚举排序
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public int Sort { get; set; }
        
        /// <summary>
        /// 枚举因子可以用来处理枚举间的关系
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public int EnumFactor { get; set; }

        /// <summary>
        /// 是否选中（默认值）
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public bool IsDefault { get; set; }
    }
}
