using Bamanna.DouDian.Api;
using Bamanna.DouDian.DouDian.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.DouDian.Interface
{
    public interface IDouDianManager:IApiManagerBase
    {
        Task<PackageListResponse> GetPackageList(PackageListRequest request, string cookie);

        Task<ReceiveInfoResponse> GetReceiveInfo(ReceiveInfoRequest request, string cookie);
    }
}
