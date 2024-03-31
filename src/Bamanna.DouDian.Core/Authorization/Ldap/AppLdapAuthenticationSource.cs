using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Bamanna.DouDian.Authorization.Users;
using Bamanna.DouDian.MultiTenancy;

namespace Bamanna.DouDian.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}