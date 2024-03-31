using Abp.Domain.Services;

namespace Bamanna.DouDian
{
    public abstract class DouDianDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected DouDianDomainServiceBase()
        {
            LocalizationSourceName = DouDianConsts.LocalizationSourceName;
        }
    }
}
