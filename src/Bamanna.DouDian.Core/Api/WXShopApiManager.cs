using Abp.Runtime.Caching;
using Bamanna.DouDian.Api.Dto.WXShop;
using Bamanna.DouDian.Infrastructure.Modules;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Api
{
    public class WXShopApiManager : ApiManagerBase, IWXShopApiManager
    {
        private readonly IWXShopApiAuthManager _wXShopApiAuthManager;

        public WXShopApiManager(
            IWXShopApiAuthManager wXShopApiAuthManager) {
            _wXShopApiAuthManager = wXShopApiAuthManager;
            ContentType = ContentType.Json;
            ConvertType = ConvertType.Camel;
            _settings = new Lazy<JsonSerializerSettings>(() =>
            {
                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                };
                return settings;
            });
        }

        public override async Task<TOutput> HttpRequest<TOutput, TInput>(string path, Dictionary<string, string> header, TInput body, HttpMethod httpMethod)
        {
            var token = await _wXShopApiAuthManager.GetAccessToken();
            return await base.HttpRequest<TOutput, TInput>(path + "?access_token=" + token.ToString(), header, body, httpMethod);
        }
    }
}
