using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bamanna.DouDian.Web.Controllers;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Controllers
{
    [Area("AppAreaName")]
    [AbpMvcAuthorize]
    public class WelcomeController : DouDianControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}