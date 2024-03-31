using Abp;

namespace Bamanna.DouDian
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="DouDianDomainServiceBase"/>.
    /// For application services inherit DouDianAppServiceBase.
    /// </summary>
    public abstract class DouDianServiceBase : AbpServiceBase
    {
        protected DouDianServiceBase()
        {
            LocalizationSourceName = DouDianConsts.LocalizationSourceName;
        }
    }
}