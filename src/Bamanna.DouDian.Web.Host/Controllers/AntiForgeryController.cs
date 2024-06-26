﻿using Microsoft.AspNetCore.Antiforgery;

namespace Bamanna.DouDian.Web.Controllers
{
    public class AntiForgeryController : DouDianControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
