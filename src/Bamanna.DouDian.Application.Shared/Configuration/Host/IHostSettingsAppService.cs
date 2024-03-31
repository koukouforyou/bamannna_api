using System.Threading.Tasks;
using Abp.Application.Services;
using Bamanna.DouDian.Configuration.Host.Dto;

namespace Bamanna.DouDian.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
