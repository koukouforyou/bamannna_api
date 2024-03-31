using System.Threading.Tasks;
using Abp.Application.Services;
using Bamanna.DouDian.Install.Dto;

namespace Bamanna.DouDian.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}