using Bamanna.DouDian.Infrastructure.Modules.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{

    /// <summary>
    /// 分页过滤并且支持排序Input类
    /// </summary>
    public class PagedSortedAndFilteredDtoInput<TPrimaryKey>: PagedAndSortedDtoInput<TPrimaryKey>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>The filter.</value>
        public virtual string Filter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedSortedAndFilteredDtoInput"/> class.
        /// </summary>
        public PagedSortedAndFilteredDtoInput() : base()
        {
        }
    }

    /// <summary>
    /// Class PagedSortedAndFilteredDtoInput.
    /// </summary>
    /// <seealso cref="Bamanna.DouDian.Infrasturcture.Modules.Common.Dto.PagedAndSortedDtoInput" />
    public class PagedSortedAndFilteredDtoInput: PagedSortedAndFilteredDtoInput<Guid>
    {

    }
}
