using Abp.AspNetCore.Mvc.ViewComponents;

namespace Bamanna.DouDian.Web.Views
{
    public abstract class DouDianViewComponent : AbpViewComponent
    {
        protected DouDianViewComponent()
        {
            LocalizationSourceName = DouDianConsts.LocalizationSourceName;
        }
    }
}