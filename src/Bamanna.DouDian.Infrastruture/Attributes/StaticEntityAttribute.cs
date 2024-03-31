using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 数据反射自定义属性
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class StaticEntityAttribute : ModelEntityAttribute
    {
        /// <summary>
        /// 表名
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string TableName { get; set; }
    }
}
