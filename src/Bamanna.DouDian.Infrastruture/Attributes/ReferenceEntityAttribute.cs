using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 引用属性（实体间相互引用，一对多时为集合）
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ReferenceEntityAttribute : Attribute
    {
         /// <summary>
        /// 构造函数
        /// </summary>
        public ReferenceEntityAttribute()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="refEntityName">引用实体名称</param>
        /// <param name="refAttributeName">引用属性名称</param>
        /// <param name="isCollection">是否集合</param>
        public ReferenceEntityAttribute(string refEntityName, string refAttributeName, bool isCollection)
        {
            this.ReferenceEntityName = refEntityName;
            this.ReferenceAttributeName = refAttributeName;
            this.IsCollection = isCollection;
        }

        /// <summary>
        /// 引用实体名称
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string ReferenceEntityName { get; set; }

        /// <summary>
        /// 引用实体属性
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public string ReferenceAttributeName { get; set; }

        /// <summary>
        /// 是否为集合
        /// </summary>
        [DataMember]
        [XmlAttribute]
        public bool IsCollection { get; set; }
    }
}
