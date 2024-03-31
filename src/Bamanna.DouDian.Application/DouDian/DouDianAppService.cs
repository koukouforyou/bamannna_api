using Bamanna.DouDian.DouDian.Interface;
using Bamanna.DouDian.Infrasturcture.Modules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bamanna.DouDian.DouDian
{
    public class DouDianAppService : UnifyAppServiceBase
    {
        private readonly IDouDianManager _douDianManager;

        private int size = 50;

        public DouDianAppService(IDouDianManager douDianManager)
        {
            _douDianManager = douDianManager;
        }

        [HttpPost]
        public async Task<Dictionary<long, string>> GetPhoneNumber(string cookie) {

            var result = new Dictionary<long,string>();
            var temp = await _douDianManager.GetPackageList(new Dto.PackageListRequest { order_by = "deliver_time", pageSize = size, page = 0 },cookie);
            for(int i=0;i<=Math.Ceiling((double)temp.total/size);i++)
            {
                foreach (var item in (await _douDianManager.GetPackageList(new Dto.PackageListRequest
                {
                    order_by = "deliver_time",
                    pageSize = size,
                    page = i
                }, cookie)).data)
                {
                    Thread.Sleep(3000);
                    var temp2 = await _douDianManager.GetReceiveInfo(new Dto.ReceiveInfoRequest { tracking_no = item.tracking_no }, cookie);
                    try
                    {
                        result.Add(temp2.data.receive_info.post_tel, temp2.data.receive_info.post_receiver);
                        Console.WriteLine("已添加:" + temp2.data.receive_info.post_tel + ":" + temp2.data.receive_info.post_receiver);

                    }
                    catch
                    {
                        Console.WriteLine("异常：" + item.tracking_no);
                    }
                }
            }
            return result;
        }
    }
}
