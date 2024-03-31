using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamanna.DouDian
{
    [DependsOn(typeof(DouDianClientModule), typeof(AbpAutoMapperModule))]
    public class DouDianXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DouDianXamarinSharedModule).GetAssembly());
        }
    }
}