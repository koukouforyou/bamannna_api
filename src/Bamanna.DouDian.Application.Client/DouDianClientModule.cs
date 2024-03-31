using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Bamanna.DouDian
{
    public class DouDianClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DouDianClientModule).GetAssembly());
        }
    }
}
