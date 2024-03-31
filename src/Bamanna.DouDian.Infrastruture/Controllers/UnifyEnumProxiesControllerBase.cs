using System.Net.Http;
using System.Net.Http.Headers;
using Abp.Auditing;
using Abp.Web.Models;

using Microsoft.AspNetCore.Mvc;
using Bamanna.DouDian.Infrastructure.Web.WebDouDian.Scripting;

namespace Bamanna.DouDian.Infrastructure.Web.Controllers
{
    [DontWrapResult]
    [DisableAuditing]
    public class UnifyEnumProxiesControllerBase : UnifyWebControllerBase
    {
        public UnifyEnumProxiesControllerBase()
        {

        }

        [Produces("text/javascript", "text/plain")]
        public string Get()
        {
            IScriptProxyGenerator enumProxy = new EnumProxyGenerator();

            var script = enumProxy.Generate();

            return script;
        }
    }
}
