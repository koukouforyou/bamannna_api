using Microsoft.AspNetCore.Mvc;
using Bamanna.DouDian.Web.Controllers;

namespace Bamanna.DouDian.Web.Public.Controllers
{
    public class AboutController : DouDianControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}