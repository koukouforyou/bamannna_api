using Abp.Application.Services;
using Abp.Extensions;
using Bamanna.DouDian.DouDianClient;

namespace Bamanna.DouDian
{
    public abstract class ProxyAppServiceBase : IApplicationService
    {
        public AbpDouDianClient DouDianClient { get; set; }

        public const string DouDianBaseUrl = "api/services/app/";

        private readonly string _serviceUrlSegment;

        protected ProxyAppServiceBase()
        {
            _serviceUrlSegment = GetServiceUrlSegmentByConvention();
        }

        protected string GetEndpoint(string methodName)
        {
            return DouDianBaseUrl + _serviceUrlSegment + "/" + methodName;
        }

        private string GetServiceUrlSegmentByConvention()
        {
            return GetType()
                .Name
                .RemovePreFix("Proxy")
                .RemovePostFix("AppServiceProxy", "AppService");
        }
    }
}