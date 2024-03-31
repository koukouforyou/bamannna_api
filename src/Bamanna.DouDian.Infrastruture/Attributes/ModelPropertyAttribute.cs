using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// Model属性自定义属性
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ModelPropertyAttribute : AttributeBase
    {
        /// <summary>
        /// 是否数据库字段
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public bool IsDbfield { get; set; }
    }
}
