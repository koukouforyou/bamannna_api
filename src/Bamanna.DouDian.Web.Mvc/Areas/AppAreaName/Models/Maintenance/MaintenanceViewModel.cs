using System.Collections.Generic;
using Bamanna.DouDian.Caching.Dto;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}