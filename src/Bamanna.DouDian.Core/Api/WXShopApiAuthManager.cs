using Abp.Runtime.Caching;
using Bamanna.DouDian.Api.Dto.WXShop;
using Bamanna.DouDian.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Api
{
    public class WXShopApiAuthManager : ApiManagerBase, IWXShopApiAuthManager
    {
        private readonly ICacheManager _cacheManager;

        public WXShopApiAuthManager(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        public async Task<string> GetAccessToken()
        {
            var cache = _cacheManager.GetCache("wx");
            if (cache.GetOrDefault("wx_accesstoken") == null || (cache.GetOrDefault("wx_accesstoken") != null &&Convert.ToDateTime(cache.GetOrDefault("wx_tokenTime")) > DateTime.Now))
            {
                var result = await HttpRequest<WXShopAccessTokenResponseDto, WXShopAccessTokenRequestDto>("https://api.weixin.qq.com/cgi-bin/token", null, new WXShopAccessTokenRequestDto
                {
                    grant_type = "client_credential",
    
                    //羊绒
                    //appid = "wx7ae76039039c21f9",
                    //secret = "70fff857c370d0f712128cb706af3538"

                    //服饰
                    appid = "wx9ad13158c560f5ef",
                    secret = "0c5457d92b594db383b53ee738edd09f"
                }, HttpMethod.Get);
                await cache.SetAsync("wx_accesstoken", result.access_token);
                await cache.SetAsync("wx_tokentime", DateTime.Now.AddSeconds(result.expires_in));
                return result.access_token;
            }
            else
            {
                return Convert.ToString(cache.GetOrDefault("wx_accesstoken").ToString());
            }
        }
    }
}
