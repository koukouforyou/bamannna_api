using System;
using System.Collections.Generic;
using System.Text;

namespace Bamanna.DouDian.Api.Dto.WXShop
{
    public class WXShopDto
    {

    }

    public class WXShopAccessTokenResponseDto
    { 
        public string access_token { get; set; }

        public double expires_in { get; set; }
    }

    public class WXShopAccessTokenRequestDto
    { 

        public string grant_type { get; set; }
        public string appid { get; set; }
        public string secret { get; set; }
    }
}
