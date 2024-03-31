using Abp.AspNetCore.Mvc.Authorization;
using Bamanna.DouDian.Authorization;
using Bamanna.DouDian.Storage;
using Abp.BackgroundJobs;

namespace Bamanna.DouDian.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}