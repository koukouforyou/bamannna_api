using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrasturcture.Modules.Common.Dto
{
    /// <summary>
    /// 七牛Token Output类
    /// </summary>
    public class QiniuTokenOutput : UnifyEntityDtoOutputBase
    {
        /// <summary>
        /// Gets or sets the uptoken.
        /// </summary>
        /// <value>The uptoken.</value>
        public string Uptoken { get; set; }
    }
}
