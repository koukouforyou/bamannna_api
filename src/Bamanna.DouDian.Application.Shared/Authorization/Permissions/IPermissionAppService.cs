using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.Authorization.Permissions.Dto;

namespace Bamanna.DouDian.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
