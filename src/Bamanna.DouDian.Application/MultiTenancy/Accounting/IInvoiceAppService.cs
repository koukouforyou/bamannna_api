using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.MultiTenancy.Accounting.Dto;

namespace Bamanna.DouDian.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
