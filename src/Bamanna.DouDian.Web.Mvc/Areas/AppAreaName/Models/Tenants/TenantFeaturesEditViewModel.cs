using Abp.AutoMapper;
using Bamanna.DouDian.MultiTenancy;
using Bamanna.DouDian.MultiTenancy.Dto;
using Bamanna.DouDian.Web.Areas.AppAreaName.Models.Common;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}