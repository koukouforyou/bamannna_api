using Abp.AspNetCore.Mvc.Authorization;
using Bamanna.DouDian.Storage;

namespace Bamanna.DouDian.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}