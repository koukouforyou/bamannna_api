using Abp.Auditing;
using Abp.Authorization;
using Bamanna.DouDian.Infrastructure.Extentions;
using Bamanna.DouDian.Infrasturcture.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.WXShop
{
    [DisableAuditing]
    [AbpAllowAnonymous]
    public class AAAAnalyseAppService : UnifyAppServiceBase
    {
        public AAAAnalyseAppService() { }

        [HttpPost]
        [DisableAuditing]
        public async Task<Dictionary<string, AnalyseResult>> GetAnalyseByMiniShop(IFormFile file)
        {
            var result = new Dictionary<string, AnalyseResult>();
            DataTable dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        if (result.ContainsKey(Convert.ToString(row["商品编码(平台)"])))
                        {
                        }
                        else
                        {
                            result.Add(Convert.ToString(row["商品编码(平台)"]), new AnalyseResult(Convert.ToString(row["商品编码(平台)"]), Convert.ToString(row["商品编码(自定义)"]), Convert.ToString(row["商品名称"])));
                        }

                        //if (Convert.ToString(row["支付时间"]) == "")
                        //{
                        //    result[Convert.ToString(row["商品编码(平台)"])].AddNotPayed();
                        //}
                        if (Convert.ToString(row["商品售后"]) == "退款完成")
                        {
                            result[Convert.ToString(row["商品编码(平台)"])].AddRefund();
                        }
                        if (Convert.ToString(row["商品售后"]) == "退货退款完成")
                        {
                            result[Convert.ToString(row["商品编码(平台)"])].AddReturn();
                        }
                        if (Convert.ToString(row["商品发货"]) == "已发货" && Convert.ToString(row["商品售后"]) == "无")
                        {
                            result[Convert.ToString(row["商品编码(平台)"])].AddDeal();
                        }
                    }
                    catch { }
                }
            }
            return result;
        }

        [HttpPost]
        [DisableAuditing]
        public async Task<Dictionary<string, AnalyseResult>> GetAnalyseByDouDian(IFormFile file) {
            var result = new Dictionary<string, AnalyseResult>();
            DataTable dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    try
                    {
                        if (result.ContainsKey(Convert.ToString(row["商品ID"])))
                        {
                        }
                        else
                        {
                            result.Add(Convert.ToString(row["商品ID"]), new AnalyseResult(Convert.ToString(row["商品ID"]), Convert.ToString(row["商家编码"]), Convert.ToString(row["选购商品"])));
                        }

                        //if (Convert.ToString(row["支付完成时间"]) == "")
                        //{
                        //    result[Convert.ToString(row["商品ID"])].AddNotPayed();
                        //}
                        if (Convert.ToString(row["支付完成时间"]) != ""&& Convert.ToString(row["发货时间"]) == "")
                        {
                            result[Convert.ToString(row["商品ID"])].AddRefund();
                        }
                        if (Convert.ToString(row["支付完成时间"]) != "" && Convert.ToString(row["发货时间"]) != "" && Convert.ToString(row["售后状态"]) == "退款成功")
                        {
                            result[Convert.ToString(row["商品ID"])].AddReturn();
                        }
                        if (Convert.ToString(row["支付完成时间"]) != "" && Convert.ToString(row["发货时间"]) != "" && Convert.ToString(row["订单状态"]) == "已完成" && Convert.ToString(row["售后状态"])!="退款成功")
                        {
                            result[Convert.ToString(row["商品ID"])].AddDeal();
                        }
                    }
                    catch { }
                }
            }
            return result;
        }

        public class AnalyseResult
        {

            public AnalyseResult(string Id, string SNB, string Name)
            {
                this.Id = Id;
                this.SNB = SNB;
                this.Name = Name;
            }
            public string Id { get; set; }

            public string SNB { get; set; }

            public string Name { get; set; }

            public int Total { get; set; }

            //public double NotPayedRate { get; set; }

            //public int NotPayed { get; set; }

            public double RefundRate { get; set; }

            public int Refund { get; set; }

            public double ReturnRate { get; set; }

            public int Return { get; set; }

            public double DealRate { get; set; }

            public int Deal { get; set; }

            //public void AddNotPayed()
            //{
            //    this.NotPayed += 1; Refresh();
            //}

            public void AddRefund()
            {
                this.Refund += 1; Refresh();
            }

            public void AddReturn()
            {
                this.Return += 1; Refresh();
            }

            public void AddDeal()
            {
                this.Deal += 1; Refresh();
            }

            public void Refresh()
            {
                this.Total += 1;
                //this.NotPayedRate = (double)this.NotPayed / this.Total;
                this.RefundRate = Math.Round((double)this.Refund / this.Total,2);
                this.ReturnRate = Math.Round((double)this.Return / this.Total,2);
                this.DealRate = Math.Round((double)this.Deal / this.Total, 2);
            }
        }
    }
}
