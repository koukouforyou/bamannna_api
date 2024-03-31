using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Bamanna.DouDian.Authorization;

namespace Bamanna.DouDian
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(DouDianCoreModule)
        )]
    public class DouDianApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DouDianApplicationModule).GetAssembly());
        }
    }
}