using Abp.AutoMapper;
using Bamanna.DouDian.MultiTenancy.Dto;

namespace Bamanna.DouDian.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(RegisterTenantOutput))]
    public class TenantRegisterResultViewModel : RegisterTenantOutput
    {
        public string TenantLoginAddress { get; set; }
    }
}