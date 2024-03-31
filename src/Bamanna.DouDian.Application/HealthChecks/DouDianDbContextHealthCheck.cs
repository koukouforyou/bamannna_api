using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Bamanna.DouDian.EntityFrameworkCore;

namespace Bamanna.DouDian.HealthChecks
{
    public class DouDianDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public DouDianDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("DouDianDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("DouDianDbContext could not connect to database"));
        }
    }
}
