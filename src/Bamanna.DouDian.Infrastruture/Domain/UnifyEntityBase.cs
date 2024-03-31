using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Bamanna.DouDian.Infrastructure.Filters;

namespace Yeban.Infrastructure.Domain
{
    public class UnifyEntityBase<TPrimaryKey> : FullAuditedEntity<TPrimaryKey>, IMayHaveTenant, IPassivable, IMayHaveOwner
    {
        private long? _ownerId;

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
        /// 所属人
        /// </summary>
        [DisplayName("所属人Id")]
        public virtual long? OwnerId
        {
            get
            {
                if ((_ownerId == null || _ownerId < 1) && CreatorUserId.HasValue)
                {
                    _ownerId = CreatorUserId.Value;
                }
                return _ownerId;
            }
            set
            {
                _ownerId = value;
            }
        }

        /// <summary>
        /// 启用状态
        /// </summary>
        [DisplayName("启用状态")]
        public virtual bool IsActive { get; set; }


        /// <summary>
        /// 租户Id
        /// </summary>
        [DisplayName("租户Id")]
        public virtual int? TenantId { get; set; }

        protected UnifyEntityBase()
        {
            IsActive = true;
        }
    }

    /// <summary>
    /// 所有实体基类
    /// </summary>
    public abstract class UnifyEntityBase : UnifyEntityBase<Guid>
    {
        protected UnifyEntityBase() : base()
        {
        }
    }
}
