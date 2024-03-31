using Bamanna.DouDian.Editions.Dto;

namespace Bamanna.DouDian.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }
    }
}
