﻿using System;
using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Bamanna.DouDian.Web.Controllers
{
    public abstract class DouDianControllerBase : AbpController
    {
        protected DouDianControllerBase()
        {
            LocalizationSourceName = DouDianConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected void SetTenantIdCookie(int? tenantId)
        {
            Response.Cookies.Append(
                "Abp.TenantId",
                tenantId?.ToString(),
                new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddYears(5),
                    Path = "/"
                }
            );
        }
    }
}