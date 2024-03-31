using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrastructure.Filters
{
    public interface IMustHaveVendor
    {
        long VendorId { get; set; }
    }
}
