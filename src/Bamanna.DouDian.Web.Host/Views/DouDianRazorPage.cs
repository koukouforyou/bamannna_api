using Abp.AspNetCore.Mvc.Views;

namespace Bamanna.DouDian.Web.Views
{
    public abstract class DouDianRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected DouDianRazorPage()
        {
            LocalizationSourceName = DouDianConsts.LocalizationSourceName;
        }
    }
}
