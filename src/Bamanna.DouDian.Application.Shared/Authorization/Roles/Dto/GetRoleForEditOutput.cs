using System.Collections.Generic;
using Bamanna.DouDian.Authorization.Permissions.Dto;

namespace Bamanna.DouDian.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}