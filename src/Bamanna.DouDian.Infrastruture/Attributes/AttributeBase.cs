using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 自定义属性基类
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false)]
    public class AttributeBase : Attribute
    {
        /// <summary>
        /// ID：默认为GUID字符
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string ID { get; set; }

        /// <summary>
        /// 名称（建议为英文或者为Pascal格式）
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// 显示名称：可作为显示标签
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string DisplayName { get; set; }

        /// <summary>
        /// 备注：可作为对用户的提示
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string Memo { get; set; }
    }
}
