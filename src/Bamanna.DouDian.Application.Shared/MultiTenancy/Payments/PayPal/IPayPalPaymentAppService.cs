using System.Threading.Tasks;
using Abp.Application.Services;
using Bamanna.DouDian.MultiTenancy.Payments.PayPal.Dto;

namespace Bamanna.DouDian.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
