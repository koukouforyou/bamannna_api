using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// Unify.Application层所有InputDto基类
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class UnifyEntityDtoInputBase<TPrimaryKey> : UnifyEntityDtoBase<TPrimaryKey>
    {
        /// <summary>
        /// 请求ID，暂时无效
        /// </summary>
        public Guid? RequestId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnifyEntityDtoInputBase{TPrimaryKey}"/> class.
        /// </summary>
        public UnifyEntityDtoInputBase()
        {
            if (!RequestId.HasValue)
            {
                RequestId = Guid.NewGuid();
            }
        }
    }

    /// <summary>
    /// Unify.Application层所有InputDto基类
    /// </summary>
    public abstract class UnifyEntityDtoInputBase : UnifyEntityDtoInputBase<Guid>
    {
    }
}
