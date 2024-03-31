using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Bamanna.DouDian.Authorization.Permissions.Dto;
using Bamanna.DouDian.Web.Areas.AppAreaName.Models.Common;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}