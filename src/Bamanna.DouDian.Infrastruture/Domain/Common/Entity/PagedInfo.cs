using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Bamanna.DouDian.Infrastructure
{
    /// <summary>
    /// 分页信息
    /// </summary>
    public class PagedInfo
    {
        /// <summary>
        /// 每页几条
        /// </summary>
        [Range(1, UnifyConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        /// <summary>
        /// 跳过条数
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string Sorting { get; set; }


    }
}
