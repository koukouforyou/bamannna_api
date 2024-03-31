using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamanna.DouDian
{
    [DependsOn(typeof(DouDianXamarinSharedModule))]
    public class DouDianXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DouDianXamarinIosModule).GetAssembly());
        }
    }
}