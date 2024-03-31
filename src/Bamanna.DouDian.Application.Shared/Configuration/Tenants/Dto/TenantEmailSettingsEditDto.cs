using Abp.Auditing;
using Bamanna.DouDian.Configuration.Dto;

namespace Bamanna.DouDian.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}