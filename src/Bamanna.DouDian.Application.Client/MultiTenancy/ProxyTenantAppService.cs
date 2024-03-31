using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.MultiTenancy.Dto;

namespace Bamanna.DouDian.MultiTenancy
{
    public class ProxyTenantAppService : ProxyAppServiceBase, ITenantAppService
    {
        public async Task<PagedResultDto<TenantListDto>> GetTenants(GetTenantsInput input)
        {
            return await DouDianClient.GetAsync<PagedResultDto<TenantListDto>>(GetEndpoint(nameof(GetTenants)), input);
        }

        public async Task CreateTenant(CreateTenantInput input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(CreateTenant)), input);
        }

        public async Task<TenantEditDto> GetTenantForEdit(EntityDto input)
        {
            return await DouDianClient.GetAsync<TenantEditDto>(GetEndpoint(nameof(GetTenantForEdit)), input);
        }

        public async Task UpdateTenant(TenantEditDto input)
        {
            await DouDianClient.PutAsync(GetEndpoint(nameof(UpdateTenant)), input);
        }

        public async Task DeleteTenant(EntityDto input)
        {
            await DouDianClient.DeleteAsync(GetEndpoint(nameof(DeleteTenant)), input);
        }

        public async Task<GetTenantFeaturesEditOutput> GetTenantFeaturesForEdit(EntityDto input)
        {
            return await DouDianClient.GetAsync<GetTenantFeaturesEditOutput>(GetEndpoint(nameof(GetTenantFeaturesForEdit)), input);
        }

        public async Task UpdateTenantFeatures(UpdateTenantFeaturesInput input)
        {
            await DouDianClient.PutAsync(GetEndpoint(nameof(UpdateTenantFeatures)), input);
        }

        public async Task ResetTenantSpecificFeatures(EntityDto input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(ResetTenantSpecificFeatures)), input);
        }

        public async Task UnlockTenantAdmin(EntityDto input)
        {
            await DouDianClient.PostAsync(GetEndpoint(nameof(UnlockTenantAdmin)), input);
        }
    }
}