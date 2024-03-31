using System.Collections.Generic;
using MvvmHelpers;
using Bamanna.DouDian.Models.NavigationMenu;

namespace Bamanna.DouDian.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}