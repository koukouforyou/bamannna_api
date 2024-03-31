using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamanna.DouDian
{
    [DependsOn(typeof(DouDianXamarinSharedModule))]
    public class DouDianXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DouDianXamarinAndroidModule).GetAssembly());
        }
    }
}