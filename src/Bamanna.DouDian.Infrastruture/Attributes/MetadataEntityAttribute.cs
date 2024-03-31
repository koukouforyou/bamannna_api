using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 元数据自定义属性
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class MetadataEntityAttribute : StaticEntityAttribute
    {
    }
}
