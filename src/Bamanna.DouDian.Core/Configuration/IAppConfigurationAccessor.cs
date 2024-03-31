using Microsoft.Extensions.Configuration;

namespace Bamanna.DouDian.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
