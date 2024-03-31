using System.Collections.Generic;
using Bamanna.DouDian.Editions;
using Bamanna.DouDian.Editions.Dto;
using Bamanna.DouDian.MultiTenancy.Payments;
using Bamanna.DouDian.MultiTenancy.Payments.Dto;

namespace Bamanna.DouDian.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
