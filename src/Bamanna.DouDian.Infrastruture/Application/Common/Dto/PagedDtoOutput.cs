using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using Bamanna.DouDian.Infrasturcture.Modules;
using Yeban.Infrastructure.Domain;
using Bamanna.DouDian.Infrastructure;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// 返回分页结果输出类
    /// </summary>
    /// <typeparam name="Dto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class PagedDtoOutput<Dto, TEntity, TPrimaryKey> : PagedResultDto<Dto>
        where Dto : UnifyEntityDtoOutputBase<TPrimaryKey>
        where TEntity : UnifyEntityBase<TPrimaryKey>
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public PagedDtoOutput() : base()
        {
        }

        /// <summary>
        /// 手动设置totalCount,items
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="items"></param>
        public PagedDtoOutput(int totalCount, IReadOnlyList<Dto> items) : base(totalCount, items)
        {

        }

        /// <summary>
        /// 直接从Core层PagedResult转化而来
        /// </summary>
        /// <param name="result"></param>
        public PagedDtoOutput(PagedResult<TEntity, TPrimaryKey> result) : this(result.TotalCount, result.Items.MapTo<IReadOnlyList<Dto>>())
        {
        }
    }

    /// <summary>
    /// 返回分页结果输出类
    /// </summary>
    /// <typeparam name="Dto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public class PagedDtoOutput<Dto, TEntity> : PagedDtoOutput<Dto, TEntity, Guid>
        where Dto : UnifyEntityDtoOutputBase
        where TEntity : UnifyEntityBase
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public PagedDtoOutput() : base()
        {
        }

        /// <summary>
        /// 手动设置totalCount,items
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="items"></param>
        public PagedDtoOutput(int totalCount, IReadOnlyList<Dto> items) : base(totalCount, items)
        {

        }

        /// <summary>
        /// 直接从Core层PagedResult转化而来
        /// </summary>
        /// <param name="result"></param>
        public PagedDtoOutput(PagedResult<TEntity,Guid> result) : base(result)
        {
        }
    }
}
