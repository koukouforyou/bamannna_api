using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Bamanna.DouDian.Infrastructure.Attributes;

namespace Bamanna.DouDian.Infrastructure.Types
{
    /// <summary>
    /// 操作类型
    /// </summary>
    [Flags]
    [DataContract]
    public enum ActionsType
    {
        /// <summary>
        /// 创建
        /// </summary>
        [EnumMember]
        Create = 1,

        /// <summary>
        /// 删除
        /// </summary>
        [EnumMember]
        Delete = 2,

        /// <summary>
        /// 更新
        /// </summary>
        [EnumMember]
        Update = 4,


        /// <summary>
        /// 得到
        /// </summary>
        [EnumMember]
        Get = 8,

        /// <summary>
        /// 分页查询
        /// </summary>
        [EnumMember]
        PagedQuery = 16,

        /// <summary>
        /// 启用/禁用
        /// </summary>
        [EnumMember]
        Active = 32,
    }
}
