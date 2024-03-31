using System.Threading.Tasks;
using Abp.Application.Services;
using Bamanna.DouDian.Configuration.Tenants.Dto;

namespace Bamanna.DouDian.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
