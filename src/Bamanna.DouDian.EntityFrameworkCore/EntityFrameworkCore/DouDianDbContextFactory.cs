using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Bamanna.DouDian.Configuration;
using Bamanna.DouDian.Web;

namespace Bamanna.DouDian.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class DouDianDbContextFactory : IDesignTimeDbContextFactory<DouDianDbContext>
    {
        public DouDianDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DouDianDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            DouDianDbContextConfigurer.Configure(builder, configuration.GetConnectionString(DouDianConsts.ConnectionStringName));

            return new DouDianDbContext(builder.Options);
        }
    }
}