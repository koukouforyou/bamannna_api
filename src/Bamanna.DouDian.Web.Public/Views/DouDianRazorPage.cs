using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Bamanna.DouDian.Web.Public.Views
{
    public abstract class DouDianRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected DouDianRazorPage()
        {
            LocalizationSourceName = DouDianConsts.LocalizationSourceName;
        }
    }
}
