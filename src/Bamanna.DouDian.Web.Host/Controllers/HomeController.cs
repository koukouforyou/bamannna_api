using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Bamanna.DouDian.Web.Controllers
{
    public class HomeController : DouDianControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Ui");
        }
    }
}
