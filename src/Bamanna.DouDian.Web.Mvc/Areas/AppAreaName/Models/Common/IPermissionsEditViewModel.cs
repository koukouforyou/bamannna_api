using System.Collections.Generic;
using Bamanna.DouDian.Authorization.Permissions.Dto;

namespace Bamanna.DouDian.Web.Areas.AppAreaName.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<string> GrantedPermissionNames { get; set; }
    }
}