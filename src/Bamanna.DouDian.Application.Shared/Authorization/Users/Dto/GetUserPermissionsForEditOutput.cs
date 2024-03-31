using System.Collections.Generic;
using Bamanna.DouDian.Authorization.Permissions.Dto;

namespace Bamanna.DouDian.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}