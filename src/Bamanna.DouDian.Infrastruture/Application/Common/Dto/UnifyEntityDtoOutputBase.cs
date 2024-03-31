using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// Unify.Application层所有OutputDto基类
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class UnifyEntityDtoOutputBase<TPrimaryKey> : UnifyEntityDtoBase<TPrimaryKey>, IPassivable, IHasCreationTime
    {
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [MaxLength(64)]
        public virtual string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        [MaxLength(256)]
        public virtual string Memo { get; set; }

        /// <summary>
        /// 启用状态
        /// </summary>
        [DisplayName("启用状态")]
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public virtual DateTime CreationTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DisplayName("最后更新时间")]
        public virtual DateTime LastModificationTime { get; set; }
    }

    /// <summary>
    /// Unify.Application层所有OutputDto基类
    /// </summary>
    public abstract class UnifyEntityDtoOutputBase : UnifyEntityDtoOutputBase<Guid>
    {
    }
}
