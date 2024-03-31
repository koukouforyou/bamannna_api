using Abp.Application.Services;
using Bamanna.DouDian.Dto;
using Bamanna.DouDian.Logging.Dto;

namespace Bamanna.DouDian.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
