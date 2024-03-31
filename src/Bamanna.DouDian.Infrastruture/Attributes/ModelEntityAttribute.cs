using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    /// <summary>
    /// Model自定义属性
    /// </summary>
    [DataContract]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModelEntityAttribute : AttributeBase
    {
    }
}
