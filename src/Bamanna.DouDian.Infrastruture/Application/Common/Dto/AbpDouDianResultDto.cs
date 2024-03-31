using System;
using System.Collections.Generic;
using System.Text;

namespace Bamanna.DouDian.Infrastructure.Modules.Common.Dto
{
    [Obsolete("因为ABP自动包装了api的输出Dto，但是swagger里的Response Class (Status 200)看不到包装部分，导致NSwag的C# Client转换错误。未来解决后将弃用。")]
    public class AbpDouDianResultDto<T>
    {
        public T Result { get; set; }
        public string TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
        public bool __abp { get; set; }
    }
}
