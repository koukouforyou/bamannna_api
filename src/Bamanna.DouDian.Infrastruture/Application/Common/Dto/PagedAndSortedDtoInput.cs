using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Extensions;
using Bamanna.DouDian.Infrasturcture.Modules;

namespace Bamanna.DouDian.Infrastructure.Modules.Common.Dto
{

    /// <summary>
    /// 分页排序Input类
    /// </summary>
    public class PagedAndSortedDtoInput<TPrimaryKey> : PagedDtoInputBase<TPrimaryKey>, ISortedResultRequest
    {
        /// <summary>
        /// 排序字段(未设置默认Id倒序排序）
        /// </summary>
        public virtual string Sorting
        {
            get;set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PagedAndSortedDtoInput() : base()
        {
            MaxResultCount = UnifyAppConsts.DefaultPageSize;
        }

        /// <summary>
        /// 转化成PagedInfo用于传到Core层
        /// </summary>
        /// <returns></returns>
        public override PagedInfo ToPagedInfo()
        {
            var re = base.ToPagedInfo();

            re.Sorting = Sorting;

            return re;
        }
    }

    /// <summary>
    /// Class PagedAndSortedDtoInput.
    /// </summary>
    /// <seealso cref="Bamanna.DouDian.Infrasturcture.Modules.Common.Dto.PagedDtoInputBase" />
    /// <seealso cref="Abp.Application.Services.Dto.ISortedResultRequest" />
    public class PagedAndSortedDtoInput: PagedAndSortedDtoInput<Guid>
    {

    }
}
