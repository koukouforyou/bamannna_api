using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Bamanna.DouDian.Configure;
using Bamanna.DouDian.Startup;
using Bamanna.DouDian.Test.Base;

namespace Bamanna.DouDian.GraphQL.Tests
{
    [DependsOn(
        typeof(DouDianGraphQLModule),
        typeof(DouDianTestBaseModule))]
    public class DouDianGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(DouDianGraphQLTestModule).GetAssembly());
        }
    }
}