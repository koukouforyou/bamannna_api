using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrastructure.Filters
{
    public class UnifyDataFilters
    {
        public const string MayHaveUser = "MayHaveUser";

        public const string MayHaveOwner = "MayHaveOwner";

        public const string MayHaveCompany = "MayHaveCompany";

        public const string MustHaveVendor = "MustHaveVendor";

        public const string MustHaveSerializer = "MustHaveSerializer";

        public static class Parameters
        {
            /// <summary>
            /// 所属人Id
            /// </summary>
            public const string OwnerId = "OwnerId";

            /// <summary>
            /// 用户Id
            /// </summary>
            public const string UserId = "UserId";

            /// <summary>
            /// 商家Id
            /// </summary>
            public const string VendorId = "VendorId";
            
            /// <summary>
            /// 序号
            /// </summary>
            public const string Serialize = "Serialize";

            /// <summary>
            /// 公司
            /// </summary>
            public const string CompanyId = "CompanyId";
        }
    }
}
