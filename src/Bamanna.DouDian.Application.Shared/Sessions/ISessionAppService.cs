using System.Threading.Tasks;
using Abp.Application.Services;
using Bamanna.DouDian.Sessions.Dto;

namespace Bamanna.DouDian.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
