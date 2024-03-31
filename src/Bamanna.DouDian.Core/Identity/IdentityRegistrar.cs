using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Bamanna.DouDian.Authentication.TwoFactor.Google;
using Bamanna.DouDian.Authorization;
using Bamanna.DouDian.Authorization.Roles;
using Bamanna.DouDian.Authorization.Users;
using Bamanna.DouDian.Editions;
using Bamanna.DouDian.MultiTenancy;

namespace Bamanna.DouDian.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>(options =>
                {
                    options.Tokens.ProviderMap[GoogleAuthenticatorProvider.Name] = new TokenProviderDescriptor(typeof(GoogleAuthenticatorProvider));
                })
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
