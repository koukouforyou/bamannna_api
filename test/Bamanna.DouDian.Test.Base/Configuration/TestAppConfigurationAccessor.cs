using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using Bamanna.DouDian.Configuration;

namespace Bamanna.DouDian.Test.Base.Configuration
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(DouDianTestBaseModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
