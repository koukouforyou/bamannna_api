using System;
using System.Runtime.Serialization;
using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 资源生成类型
    /// </summary>
    [Flags]
    [DataContract]
    [EnumType(DisplayName = "资源生成类型", Name = "ResGenerationType", EnumType = EnumType.Flags)]
    public enum ResGenerationType
    {
        /// <summary>
        /// 生成权限
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "权限", Name = "AppPermissions", IsDefault = true)]
        AppPermissions = 1,

        /// <summary>
        /// 生成Ng页面
        /// </summary>
        [EnumMember]
        [EnumValue(DisplayName = "页面", Name = "Page", IsDefault = false)]
        Page = 2,
       
    }
}
