using Abp.Application.Services.Dto;
using Bamanna.DouDian.Infrasturcture.Modules;
using Bamanna.DouDian.Infrasturcture.Modules.Common.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrastructure.Modules.Common.Dto
{
    /// <summary>
    /// 分页Input基类
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class PagedDtoInputBase<TPrimaryKey> : UnifyEntityDtoInputBase<TPrimaryKey>, IPagedResultRequest
    {
        [Range(1, UnifyAppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public PagedDtoInputBase()
        {
            MaxResultCount = UnifyAppConsts.DefaultPageSize;
        }

        //private int _skipCount = 0;
        //private int _maxSize = 5;
        //private int _size = UnifyAppConsts.DefaultPageSize;
        ///// <summary>
        ///// 第几页（从第1页开始）
        ///// </summary>
        //[DefaultValue(1)]
        //[Range(1, UnifyAppConsts.MaxPageSize)]
        //public int Index { get; set; }

        ///// <summary>
        ///// 最多显示几页
        ///// </summary>
        //[DefaultValue(99)]
        //public int MaxSize
        //{
        //    get
        //    {
        //        return _maxSize;
        //    }
        //    set
        //    {
        //        _maxSize = value;
        //    }
        //}

        ///// <summary>
        ///// 每页几条
        ///// </summary>
        //[DefaultValue(1)]
        //[Range(1, UnifyAppConsts.MaxPageSize)]
        //public int MaxResultCount
        //{
        //    get
        //    {
        //        return _size;
        //    }
        //    set
        //    {
        //        _size = value;
        //    }
        //}

        ///// <summary>
        ///// 跳过条数
        ///// </summary>
        //[Range(0, int.MaxValue)]
        //public int SkipCount
        //{
        //    get
        //    {
        //        if (_skipCount == 0)
        //        { return ((Index - 1) > 0 ? (Index - 1) : 0) * MaxResultCount; }

        //        return _skipCount;
        //    }
        //    set
        //    {
        //        _skipCount = value;
        //    }
        //}

        ///// <summary>
        ///// Initializes a new instance of the <see cref="PagedDtoInputBase{TPrimaryKey}"/> class.
        ///// </summary>
        //public PagedDtoInputBase()
        //{
        //    MaxResultCount = UnifyAppConsts.DefaultPageSize;
        //}

        /// <summary>
        /// 转化成Core层分页信息类
        /// </summary>
        /// <returns>PagedInfo.</returns>
        public virtual PagedInfo ToPagedInfo()
        {
            return new PagedInfo() { SkipCount = SkipCount, MaxResultCount = MaxResultCount };
        }
    }

    /// <summary>
    /// 分页Input基类
    /// </summary>
    public abstract class PagedDtoInputBase : PagedDtoInputBase<Guid>
    {
    }
}
