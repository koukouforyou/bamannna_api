using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.Authorization.Users.Dto;
using Bamanna.DouDian.Dto;

namespace Bamanna.DouDian.Authorization.Users
{
    public class ProxyUserAppService : ProxyAppServiceBase, IUserAppService
    {
        public async Task<PagedResultDto<UserListDto>> GetUsers(GetUsersInput input)
        {
            return await DouDianClient.GetAsync<PagedResultDto<UserListDto>>(GetEndpoint(nameof(GetUsers)), input);
        }

        public async Task<FileDto> GetUsersToExcel(GetUsersToExcelInput input)
        {
            return await DouDianClient.GetAsync<FileDto>(GetEndpoint(nameof(GetUsersToExcel)), input);
        }

        public async Task<GetUserForEditOutput> GetUserForEdit(NullableIdDto<long> input)
        {
            return await DouDianClient.GetAsync<GetUserForEditOutput>(GetEndpoint(nameof(GetUserForEdit)), input);
        }

        public async Task<GetUserPermissionsForEditOutput> GetUserPermissionsForEdit(EntityDto<long> input)
        {
            return await DouDianClient.GetAsync<GetUserPermissionsForEditOutput>(GetEndpoint(nameof(GetUserPermissionsForEdit)), input);
        }

        public async Task ResetUserSpecificPermissions(EntityDto<long> input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(ResetUserSpecificPermissions)), input);
        }

        public async Task UpdateUserPermissions(UpdateUserPermissionsInput input)
        {
            await DouDianClient.PutAsync(GetEndpoint(nameof(UpdateUserPermissions)), input);
        }

        public async Task CreateOrUpdateUser(CreateOrUpdateUserInput input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(CreateOrUpdateUser)), input);
        }

        public async Task DeleteUser(EntityDto<long> input)
        {
            await DouDianClient.DeleteAsync(GetEndpoint(nameof(DeleteUser)), input);
        }

        public async Task UnlockUser(EntityDto<long> input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(UnlockUser)), input);
        }
    }
}