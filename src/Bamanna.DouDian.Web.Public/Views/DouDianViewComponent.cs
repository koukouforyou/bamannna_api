using Abp.AspNetCore.Mvc.ViewComponents;

namespace Bamanna.DouDian.Web.Public.Views
{
    public abstract class DouDianViewComponent : AbpViewComponent
    {
        protected DouDianViewComponent()
        {
            LocalizationSourceName = DouDianConsts.LocalizationSourceName;
        }
    }
}