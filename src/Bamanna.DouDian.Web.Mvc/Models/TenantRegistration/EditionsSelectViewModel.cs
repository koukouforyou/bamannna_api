using Abp.AutoMapper;
using Bamanna.DouDian.MultiTenancy.Dto;

namespace Bamanna.DouDian.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
