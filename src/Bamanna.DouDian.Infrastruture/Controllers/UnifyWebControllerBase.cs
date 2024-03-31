using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.UI;
using Microsoft.AspNetCore.Identity;

namespace Bamanna.DouDian.Infrastructure.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// Add your methods to this class common for all controllers.
    /// </summary>
    public abstract class UnifyWebControllerBase : AbpController
    {
        public ILanguageManager LanguageManager { get; set; }

        protected UnifyWebControllerBase()
        {

        }

        protected virtual void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new UserFriendlyException(L("FormIsNotValidMessage"));
            }
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}