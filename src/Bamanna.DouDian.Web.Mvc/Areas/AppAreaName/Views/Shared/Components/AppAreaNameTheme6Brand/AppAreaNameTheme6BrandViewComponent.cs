using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bamanna.DouDian.Web.Areas.AppAreaName.Models.Layout;
using Bamanna.DouDian.Web.Session;
using Bamanna.DouDian.Web.Views;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTheme6Brand
{
    public class AppAreaNameTheme6BrandViewComponent : DouDianViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameTheme6BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
