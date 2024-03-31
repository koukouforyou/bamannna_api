using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 数据反射属性自定义属性
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class MetadataPropertyAttribute : StaticEntityPropertyAttribute
    {
    }
}
