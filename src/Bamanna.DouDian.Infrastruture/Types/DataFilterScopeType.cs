using System;
using System.Runtime.Serialization;

namespace Bamanna.DouDian.Infrastructure.Modules
{
    /// <summary>
    /// 数据过滤范围
    /// </summary>
    [Flags]
    [DataContract]
    public enum DataFilterScopeType
    {
        /// <summary>
        /// 所属用户（默认）
        /// </summary>
        [EnumMember]
        Owner = 1,

        /// <summary>
        /// 所属组织(备用)
        /// </summary>
        [EnumMember]
        BusinessUnit = 2,


        /// <summary>
        /// 所属租户
        /// </summary>
        [EnumMember]
        Tenant = 4,


        ///// <summary>
        ///// 所属租主
        ///// </summary>
        //[EnumMember]
        //[EnumValue(DisplayName = "所属租主", Name = "Host", IsDefault = false)]
        //Host = 8,
    }
}
