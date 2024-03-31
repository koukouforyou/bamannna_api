using Abp.AutoMapper;
using Bamanna.DouDian.Editions;
using Bamanna.DouDian.MultiTenancy.Payments.Dto;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.SubscriptionManagement
{
    [AutoMapTo(typeof(ExecutePaymentDto))]
    public class PaymentResultViewModel : SubscriptionPaymentDto
    {
        public EditionPaymentType EditionPaymentType { get; set; }
    }
}