using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bamanna.DouDian.Web.Areas.AppAreaName.Models.Layout;
using Bamanna.DouDian.Web.Session;
using Bamanna.DouDian.Web.Views;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameTheme12Brand
{
    public class AppAreaNameTheme12BrandViewComponent : DouDianViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppAreaNameTheme12BrandViewComponent(IPerRequestSessionCache sessionCache)
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
