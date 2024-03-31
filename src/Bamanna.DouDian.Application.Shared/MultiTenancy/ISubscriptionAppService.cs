using System.Threading.Tasks;
using Abp.Application.Services;

namespace Bamanna.DouDian.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
