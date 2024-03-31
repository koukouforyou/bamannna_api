using Bamanna.DouDian.MultiTenancy.Payments;

namespace Bamanna.DouDian.Web.Models.Payment
{
    public class CancelPaymentModel
    {
        public string PaymentId { get; set; }

        public SubscriptionPaymentGatewayType Gateway { get; set; }
    }
}