using Bamanna.DouDian.Editions;
using Bamanna.DouDian.Editions.Dto;
using Bamanna.DouDian.MultiTenancy.Payments;
using Bamanna.DouDian.Security;
using Bamanna.DouDian.MultiTenancy.Payments.Dto;

namespace Bamanna.DouDian.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
