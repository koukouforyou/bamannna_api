namespace Bamanna.DouDian.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}