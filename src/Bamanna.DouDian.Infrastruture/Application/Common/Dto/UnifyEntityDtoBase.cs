using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// Unify.Application层所有Dto基类
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class UnifyEntityDtoBase<TPrimaryKey> : EntityDto<TPrimaryKey>
    {

    }

    /// <summary>
    /// Unify.Application层所有Dto基类
    /// </summary>
    public abstract class UnifyEntityDtoBase : UnifyEntityDtoBase<Guid>
    {

    }
}
