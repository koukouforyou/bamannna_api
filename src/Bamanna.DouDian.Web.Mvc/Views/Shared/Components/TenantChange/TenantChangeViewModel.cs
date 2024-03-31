using Abp.AutoMapper;
using Bamanna.DouDian.Sessions.Dto;

namespace Bamanna.DouDian.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}