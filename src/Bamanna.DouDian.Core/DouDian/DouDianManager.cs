using Bamanna.DouDian.Api;
using Bamanna.DouDian.DouDian.Dto;
using Bamanna.DouDian.DouDian.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bamanna.DouDian.DouDian
{
    public class DouDianManager : ApiManagerBase, IDouDianManager
    {
        private readonly IDouDianApiManager _douDianApiManager;

        private readonly string source = "https://fxg.jinritemai.com/";

        public DouDianManager(IDouDianApiManager douDianApiManager)
        {
            _douDianApiManager = douDianApiManager;
        }

        public async Task<PackageListResponse> GetPackageList(PackageListRequest request, string cookie)
        {
            return await _douDianApiManager.HttpRequest<PackageListResponse, PackageListRequest>(source + "api/order/searchPackageList", new Dictionary<string, string>
            {
                { "cookie", cookie }
            }, request, HttpMethod.Get);
        }

        public async Task<ReceiveInfoResponse> GetReceiveInfo(ReceiveInfoRequest request, string cookie)
        {
            return await _douDianApiManager.HttpRequest<ReceiveInfoResponse, ReceiveInfoRequest>(source + "api/order/receiveinfoForPackage", new Dictionary<string, string>
            {
                { "cookie", cookie }
            }, request, HttpMethod.Get);
        }
    }
}
