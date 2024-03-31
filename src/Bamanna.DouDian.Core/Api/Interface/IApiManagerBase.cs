using Bamanna.DouDian.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Api
{
    public interface IApiManagerBase : IUnifyDomainServiceBase
    {
        ContentType ContentType { get; set; }

        ConvertType ConvertType { get; set; }

        Task<TOutput> HttpRequest<TOutput, TInput>(string path, Dictionary<string, string> header, TInput body, HttpMethod httpMethod) where TInput : class;

        Task<HttpResponseMessage> HttpRequestBase<TInput>(string path, Dictionary<string, string> header, TInput body, HttpMethod httpMethod) where TInput : class;
    }
}
