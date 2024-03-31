using System.Threading.Tasks;
using Abp.Application.Services;
using Bamanna.DouDian.Editions.Dto;
using Bamanna.DouDian.MultiTenancy.Dto;

namespace Bamanna.DouDian.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}