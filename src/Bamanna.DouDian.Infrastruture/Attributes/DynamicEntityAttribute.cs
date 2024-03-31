using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// 动态实体自定义属性
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DynamicEntityAttribute : ModelEntityAttribute
    {
    }
}
