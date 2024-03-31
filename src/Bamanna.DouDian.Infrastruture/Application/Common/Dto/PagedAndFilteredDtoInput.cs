using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrastructure.Modules.Common.Dto
{
    /// <summary>
    /// 分页过滤Input类
    /// </summary>
    public class PagedAndFilteredDtoInput : PagedDtoInputBase
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>The filter.</value>
        public virtual string Filter { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedAndFilteredDtoInput"/> class.
        /// </summary>
        public PagedAndFilteredDtoInput() : base()
        {
        }
    }
}
