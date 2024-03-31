using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bamanna.DouDian.Web.Areas.AppAreaName.Models.Layout;
using Bamanna.DouDian.Web.Session;
using Bamanna.DouDian.Web.Views;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTheme8Footer
{
    public class AppAreaNameTheme8FooterViewComponent : DouDianViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameTheme8FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
