using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamanna.DouDian.Startup
{
    [DependsOn(typeof(DouDianCoreModule))]
    public class DouDianGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DouDianGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}