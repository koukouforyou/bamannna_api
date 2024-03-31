using Bamanna.DouDian.Api.Dto.WXShop;
using Bamanna.DouDian.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Api
{
    public interface IWXShopApiAuthManager: IUnifyDomainServiceBase
    {
        Task<string> GetAccessToken();
    }
}
