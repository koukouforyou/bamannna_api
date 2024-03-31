using System.Threading.Tasks;
using Abp.Dependency;

namespace Bamanna.DouDian.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}