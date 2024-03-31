using System.Collections.Generic;
using Bamanna.DouDian.Editions.Dto;
using Bamanna.DouDian.MultiTenancy.Payments;

namespace Bamanna.DouDian.Web.Models.Payment
{
    public class UpgradeEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public PaymentPeriodType PaymentPeriodType { get; set; }

        public SubscriptionPaymentType SubscriptionPaymentType { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}