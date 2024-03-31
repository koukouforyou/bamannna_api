using Abp.Authorization;
using Bamanna.DouDian.Authorization.Roles;
using Bamanna.DouDian.Authorization.Users;

namespace Bamanna.DouDian.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
