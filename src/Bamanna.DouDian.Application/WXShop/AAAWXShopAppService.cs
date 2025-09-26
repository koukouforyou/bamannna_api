using Abp.Auditing;
using Abp.Authorization;
using Abp.Extensions;
using AutoMapper.Configuration.Annotations;
using Bamanna.DouDian.Api;
using Bamanna.DouDian.Infrastructure.Attributes;
using Bamanna.DouDian.Infrastructure.Extentions;
using Bamanna.DouDian.Infrasturcture.Modules;
using Bamanna.DouDian.WXShop.Dto;
using Bamanna.DouDian.WXShop.Interface;
using Castle.MicroKernel.SubSystems.Conversion;
using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.ConditionalFormatting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Bamanna.DouDian.WXShop
{
    [DisableAuditing]
    [AbpAllowAnonymous]
    public class AAAWXShopAppService : UnifyAppServiceBase
    {
        private readonly IWXShopApiAuthManager _IWXShopApiAuthManager;
        private readonly IWXShopManager _wXShopApiManager;

        private static string morningbegin = "6:30";
        private static string morningend = "12:00";

        private static string afternoonbegin = "13:30";
        private static string afternoonend = "19:00";

        private static string eveningbegin = "19:00";
        private static string eveningend = "23:59";

        TimeSpan dspMorningBegin = DateTime.Parse(morningbegin).TimeOfDay;
        TimeSpan dspMorningEnd = DateTime.Parse(morningend).TimeOfDay;

        TimeSpan dspAfternoonBegin = DateTime.Parse(afternoonbegin).TimeOfDay;
        TimeSpan dspAfternoonEnd = DateTime.Parse(afternoonend).TimeOfDay;

        TimeSpan dspEveningBegin = DateTime.Parse(eveningbegin).TimeOfDay;
        TimeSpan dspEveningEnd = DateTime.Parse(eveningend).TimeOfDay;
        public AAAWXShopAppService(IWXShopApiAuthManager wXShopApiAuthManager, IWXShopManager wXShopManager)
        {
            _IWXShopApiAuthManager = wXShopApiAuthManager;
            _wXShopApiManager = wXShopManager;
        }


        private int size = 400;

        #region Obsolete
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        public async Task<string> Test()
        {
            return await _IWXShopApiAuthManager.GetAccessToken();
        }

        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        public async Task<OrderResponse> GetOrderList(OrderRequest body)
        {
            return await _wXShopApiManager.GetOrderList(body);
        }

        /// <summary>
        /// 获取所有订单列表
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        public async Task<List<Order>> GetAllOrderList(AllOrderDto dto)
        {
            var result = new List<Order>();
            var temp = await _wXShopApiManager.GetOrderList(new OrderRequest
            {
                start_create_time = dto.start_create_time,
                end_create_time = dto.end_create_time,
                status = 100,
                page = 1,
                page_size = size,
                source = 1
            });
            result.AddRange(temp.orders);
            if (temp.total_num > size)
            {
                for (int i = 2; i <= Math.Ceiling((double)temp.total_num / size); i++)
                {
                    result.AddRange((await _wXShopApiManager.GetOrderList(new OrderRequest
                    {
                        start_create_time = dto.start_create_time,
                        end_create_time = dto.end_create_time,
                        status = 100,
                        page = i,
                        page_size = size,
                        source = 1
                    })).orders);
                }
            }
            Console.WriteLine(result.Count);
            return result;
        }

        /// <summary>
        /// 获取订单列表总价
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        public async Task<double> GetAllOrderListPrice(AllOrderDto dto)
        {
            var result = 0;
            var temp = await _wXShopApiManager.GetOrderList(new OrderRequest
            {
                start_create_time = dto.start_create_time,
                end_create_time = dto.end_create_time,
                status = 100,
                page = 1,
                page_size = size,
                source = 1
            });
            foreach (var item in temp.orders)
            {
                result += item.order_detail.price_info.order_price;
            }
            if (temp.total_num > size)
            {
                for (int i = 2; i <= Math.Ceiling((double)temp.total_num / size); i++)
                {
                    foreach (var item in (await _wXShopApiManager.GetOrderList(new OrderRequest
                    {
                        start_create_time = dto.start_create_time,
                        end_create_time = dto.end_create_time,
                        status = 100,
                        page = i,
                        page_size = size,
                        source = 1
                    })).orders)
                    {
                        result += item.order_detail.price_info.order_price;
                    }
                }
            }
            return result / 100;
        }

        /// <summary>
        /// 获取订单列表分时段业绩
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        public async Task<PriceResult> GetAllOrderListSlipePrice(AllOrderDto dto)
        {
            var result = new PriceResult();
            var temp = await _wXShopApiManager.GetOrderList(new OrderRequest
            {
                start_create_time = dto.start_create_time,
                end_create_time = dto.end_create_time,
                status = 100,
                page = 1,
                page_size = size,
                source = 1
            });
            foreach (var item in temp.orders)
            {
                if (dspAfternoonBegin < Convert.ToDateTime(item.create_time).TimeOfDay && Convert.ToDateTime(item.create_time).TimeOfDay < dspAfternoonEnd)
                {
                    result.afternoon += item.order_detail.price_info.order_price / 100;
                }
                if (dspEveningBegin < Convert.ToDateTime(item.create_time).TimeOfDay && Convert.ToDateTime(item.create_time).TimeOfDay < dspEveningEnd)
                {
                    result.evening += item.order_detail.price_info.order_price / 100;
                }
            }
            if (temp.total_num > size)
            {
                for (int i = 2; i <= Math.Ceiling((double)temp.total_num / size); i++)
                {
                    foreach (var item in (await _wXShopApiManager.GetOrderList(new OrderRequest
                    {
                        start_create_time = dto.start_create_time,
                        end_create_time = dto.end_create_time,
                        status = 100,
                        page = i,
                        page_size = size,
                        source = 1
                    })).orders)
                    {
                        if (dspAfternoonBegin < Convert.ToDateTime(item.create_time).TimeOfDay && Convert.ToDateTime(item.create_time).TimeOfDay < dspAfternoonEnd)
                        {
                            result.afternoon += item.order_detail.price_info.order_price / 100;
                        }
                        if (dspEveningBegin < Convert.ToDateTime(item.create_time).TimeOfDay && Convert.ToDateTime(item.create_time).TimeOfDay < dspEveningEnd)
                        {
                            result.evening += item.order_detail.price_info.order_price / 100;
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取订单列表分时段销售业绩（包换调班）
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        public async Task<PriceResult> GetAllOrderListSlipePriceChange(AllOrderDto dto)
        {
            ////上午调班列表
            //var morningTransferList = new List<ChangeItem> { };

            ////上午请假列表
            //var morningLeaveList = new List<ChangeItem>();

            ////上午加班列表
            //var morningOverTimeList = new List<ChangeItem> { };

            ////下午调班列表
            //var afternoonTransferList = new List<ChangeItem> {
            //    new ChangeItem{ sourcetime ="2022-04-04",sourceType = ChangeType.Afternoon,desttime = "2022-04-03"},
            //    new ChangeItem{ sourcetime = "2022-05-02",sourceType = ChangeType.Afternoon,desttime = "2022-05-03"}
            //};

            ////下午请假列表
            //var afternoonLeaveList = new List<ChangeItem>() {
            //    new ChangeItem { sourcetime = "2022-06-29" },
            //    new ChangeItem { sourcetime = "2022-06-30"},
            //    new ChangeItem { sourcetime = "2022-07-01"},
            //    new ChangeItem { sourcetime = "2022-07-08"},
            //    new ChangeItem { sourcetime = "2022-07-27"}
            //};

            ////下午加班列表
            //var afternoonOverTimeList = new List<ChangeItem> {
            //    new ChangeItem{ sourcetime = "2022-04-18",sourceType = ChangeType.Afternoon},
            //    new ChangeItem{ sourcetime = "2022-06-06",sourceType = ChangeType.Afternoon},
            //    new ChangeItem{ sourcetime = "2022-06-20",sourceType = ChangeType.Afternoon},
            //    new ChangeItem{ sourcetime = "2022-06-27",sourceType = ChangeType.Afternoon},
            //    new ChangeItem{ sourcetime = "2022-07-11",sourceType = ChangeType.Afternoon},
            //    new ChangeItem{ sourcetime = "2022-07-04",sourceType = ChangeType.Afternoon},
            //    new ChangeItem{ sourcetime = "2022-07-11",sourceType = ChangeType.Afternoon},
            //};

            ////晚上调班列表
            //var eveningTransferList = new List<ChangeItem>
            //{
            //    new ChangeItem{ sourcetime = "2022-04-03",sourceType = ChangeType.Afternoon,desttime = "2022-04-04"},
            //    new ChangeItem{ sourcetime = "2022-04-25",sourceType = ChangeType.Afternoon,desttime = "2022-04-25"},
            //    new ChangeItem{ sourcetime = "2022-05-04",sourceType = ChangeType.Morning,desttime = "2022-05-04"},
            //    new ChangeItem{ sourcetime = "2022-05-05",sourceType = ChangeType.Morning,desttime = "2022-05-05"},
            //    new ChangeItem{ sourcetime = "2022-05-09",sourceType = ChangeType.Afternoon,desttime = "2022-05-09"},
            //    new ChangeItem{ sourcetime = "2022-05-15",sourceType = ChangeType.Evening,desttime = "2022-05-11"},
            //    new ChangeItem{ sourcetime = "2022-05-21",sourceType = ChangeType.Morning,desttime = "2022-05-21"}
            //};

            ////晚上请假列表
            //var eveningLeaveList = new List<ChangeItem> {
            //    new ChangeItem { desttime = "2022-04-05"},
            //    new ChangeItem { desttime = "2022-04-15"},
            //    new ChangeItem{ desttime = "2022-04-16"},
            //    new ChangeItem{ desttime = "2022-04-18"},
            //    new ChangeItem{ desttime = "2022-04-28"},
            //    new ChangeItem{ desttime = "2022-06-09"},
            //    new ChangeItem{ desttime = "2022-06-18"},
            //    new ChangeItem{ desttime = "2022-06-20"},
            //    new ChangeItem{ desttime = "2022-06-21"},
            //    new ChangeItem{ desttime = "2022-06-22"},
            //    new ChangeItem{ desttime = "2022-06-23"},
            //    new ChangeItem{ desttime = "2022-06-24"},
            //    new ChangeItem{ desttime = "2022-06-25"},
            //    new ChangeItem{ desttime = "2022-06-27"},
            //    new ChangeItem{ desttime = "2022-06-28"},
            //};

            ////晚上加班列表
            //var eveningOverTimeList = new List<ChangeItem> {
            //    new ChangeItem{ sourcetime = "2022-05-01",sourceType = ChangeType.Evening}
            //};

            var morningbegin = "6:30";
            var morningend = "12:00";
            var afternoonbegin = "13:00";
            var afternoonend = "18:30";
            var eveningbegin = "18:30";
            var eveningend = "23:59";

            TimeSpan dspMorningBegin = DateTime.Parse(morningbegin).TimeOfDay;
            TimeSpan dspMorningEnd = DateTime.Parse(morningend).TimeOfDay;

            TimeSpan dspAfternoonBegin = DateTime.Parse(afternoonbegin).TimeOfDay;
            TimeSpan dspAfternoonEnd = DateTime.Parse(afternoonend).TimeOfDay;

            TimeSpan dspEveningBegin = DateTime.Parse(eveningbegin).TimeOfDay;
            TimeSpan dspEveningEnd = DateTime.Parse(eveningend).TimeOfDay;

            var result = new PriceResult();
            var temp = await _wXShopApiManager.GetOrderList(new OrderRequest
            {
                start_create_time = dto.start_create_time,
                end_create_time = dto.end_create_time,
                status = 100,
                page = 1,
                page_size = size,
                source = 1
            });
            for (int i = 1; i <= Math.Ceiling((double)temp.total_num / size); i++)
            {
                foreach (var item in (await _wXShopApiManager.GetOrderList(new OrderRequest
                {
                    start_create_time = dto.start_create_time,
                    end_create_time = dto.end_create_time,
                    status = 100,
                    page = i,
                    page_size = size,
                    source = 1
                })).orders)
                {
                    if (dspMorningBegin < Convert.ToDateTime(item.create_time).TimeOfDay && Convert.ToDateTime(item.create_time).TimeOfDay < dspMorningEnd)
                    {

                        result.morning += item.order_detail.price_info.order_price / 100;
                    }
                    if (dspAfternoonBegin < Convert.ToDateTime(item.create_time).TimeOfDay && Convert.ToDateTime(item.create_time).TimeOfDay < dspAfternoonEnd)
                    {


                        result.afternoon += item.order_detail.price_info.order_price / 100;
                    }
                    if (dspEveningBegin < Convert.ToDateTime(item.create_time).TimeOfDay && Convert.ToDateTime(item.create_time).TimeOfDay < dspEveningEnd)
                    {

                        result.evening += item.order_detail.price_info.order_price / 100;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取订单列表分时段销售业绩（包括调班）----分日期
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        public async Task GetAllOrderListSlipePriceChangeByDay()
        {

        }

        /// <summary>
        /// 获取售后单列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        public async Task<List<Order>> GetOnAfterSaleOrder()
        {
            var result = new List<Order>();
            var temp = await _wXShopApiManager.SearchOrderList(new SearchOrderRequest
            {
                on_aftersale_order_exist = 1,
                page = 1,
                page_size = size
            });
            result.AddRange(temp.orders);
            if (temp.total_num > size)
            {
                for (int i = 2; i <= Math.Ceiling((double)temp.total_num / size); i++)
                {
                    result.AddRange((await _wXShopApiManager.SearchOrderList(new SearchOrderRequest
                    {
                        on_aftersale_order_exist = 1,
                        page = i,
                        page_size = size
                    })).orders);
                }
            }
            Console.WriteLine(result.Count);
            return result;
        }

        /// <summary>
        /// 获取超时售后单列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        public async Task<List<long>> GetTimeoutOnAfterSaleOrder()
        {
            int timeouthour = 30;
            var result = await GetOnAfterSaleOrder();
            var list = new List<After_Sale_Order_List>();
            var aftersalelist = new List<long>();
            foreach (var item in result.Select(e => e.aftersale_detail))
            {
                aftersalelist.AddRange(item.aftersale_order_list.Select(ei => ei.aftersale_order_id));
            }

            foreach (var item in aftersalelist.SplitList(50))
            {
                list.AddRange((await _wXShopApiManager.BatchGetAfterSaleOrder(new BatchGetAfterSaleOrderRequest
                {
                    after_sale_order_id_list = item.ToArray()
                })).after_sale_order_list);
            }
            return list.Where(
                (e => (e.status == "MERCHANT_PROCESSING" &&
                (DateTime.Now - e.update_time.GetDateTimeByLong(false)).TotalHours > (72 - timeouthour))
                || (e.status == "MERCHANT_WAIT_RECEIPT" && (DateTime.Now - e.update_time.GetDateTimeByLong(false)).TotalHours > (240 - timeouthour))
                //||(e.status == "MERCHANT_REJECT_RETURN" && (DateTime.Now - e.update_time.GetDateTimeByLong(false)).TotalHours > (48 - timeouthour))
                )).ToList().Select(e => e.order_id).ToList();

        }

        /// <summary>
        /// 微信小商店报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Obsolete]
        [SwaggerIgnore]
        [DisableAuditing]
        public async Task<Dictionary<string, PriceResult>> GetMiniShopPriceChangeByDay(IFormFile file)
        {
            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            list.Add(new TaobaoSaleModel
                            {
                                date = Convert.ToDateTime(item["下单时间"]),
                                price = Convert.ToDouble(item["订单实际支付金额"])
                            });
                        }
                        catch
                        {
                            errorcount++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            Console.WriteLine(errorcount);
            return result;
        }

        /// <summary>
        /// 有赞报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableAuditing]
        [Obsolete]
        [SwaggerIgnore]
        [AbpAllowAnonymous]
        public async Task<Dictionary<string, PriceResult>> GetYouZanPriceChangeByDay(IFormFile file)
        {
            return await GetPriceChangeByDay(file, "订单创建时间", "订单实付金额");
            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            list.Add(new TaobaoSaleModel
                            {
                                date = Convert.ToDateTime(item["订单创建时间"]),
                                price = Convert.ToDouble(item["订单实付金额"])
                            });
                        }
                        catch
                        {
                            errorcount++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            Console.WriteLine(errorcount);
            return result;
        }

#endregion

        /// <summary>
        /// 视频号小店报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableAuditing]
        public async Task<Dictionary<string, PriceResult>> GetChannelShopPriceChangeByDay(IFormFile file,string channelName)
        {
            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            //筛选达人带货订单
                            if (channelName.IsNullOrEmpty() || Convert.ToString(item["带货账号昵称"]) == channelName
                                )
                            {
                                //筛选售后订单
                                if ((Convert.ToString(item["商品售后"]) != "退货退款完成"
                                || Convert.ToString(item["商品售后"]) != "退款完成")
                                && Convert.ToString(item["订单状态"]) == "已完成"
                                )
                                {
                                    list.Add(new TaobaoSaleModel
                                    {
                                        date = Convert.ToDateTime(item["订单下单时间"]),
                                        price = Convert.ToDouble(item["订单实际收款金额"])
                                    });
                                }
                            }
                            else
                            {
                                Console.WriteLine(Convert.ToString(item["带货账号昵称"]));
                            }
                        }
                        catch
                        {
                            errorcount++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            Console.WriteLine(errorcount);
            PriceResult allPriceResult = new PriceResult();
            foreach (var item in result)
            {
                allPriceResult.morning += item.Value.morning;
                allPriceResult.afternoon += item.Value.afternoon;
                allPriceResult.evening += item.Value.evening;
            }
            return result;
        }

        private async Task<Dictionary<string, PriceResult>> GetPriceChangeByDay(IFormFile file, string timename, string pricename)
        {
            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            ////筛选达人带货订单
                            //if (Convert.ToString(item["带货人视频号"]) == "紫缘阁服饰"
                            //    || Convert.ToString(item["带货人视频号"]).IsNullOrEmpty()
                            //    //|| Convert.ToString(item["商品售后"])!= "退货退款完成"
                            //    //|| Convert.ToString(item["商品售后"]) != "退款完成" 
                            //    )
                            //{
                            //    //筛选售后订单
                            //    if (Convert.ToString(item["商品售后"]) != "退货退款完成"
                            //    || Convert.ToString(item["商品售后"]) != "退款完成")
                            //    {
                            list.Add(new TaobaoSaleModel
                            {
                                date = Convert.ToDateTime(item[timename]),
                                price = Convert.ToDouble(item[pricename])
                            });
                            //    }
                            //}
                            //else
                            //{
                            //    Console.WriteLine(Convert.ToString(item["带货人视频号"]));
                            //}
                        }
                        catch
                        {
                            errorcount++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            Console.WriteLine(errorcount);
            return result;
        }

        /// <summary>
        /// 淘宝报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableAuditing]
        public async Task<Dictionary<string, PriceResult>> GetTaoBaoPriceChangeByDay(IFormFile file)
        {
            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            //筛选售后订单
                            if (Convert.ToString(item["订单状态"]) == "交易成功")
                            {
                                list.Add(new TaobaoSaleModel
                                {
                                    date = Convert.ToDateTime(item["订单创建时间"]),
                                    price = Convert.ToDouble(item["买家应付货款"])
                                });
                            }
                        }
                        catch
                        {
                            errorcount++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            Console.WriteLine(errorcount);
            PriceResult allPriceResult = new PriceResult();
            foreach (var item in result)
            {
                allPriceResult.morning += item.Value.morning;
                allPriceResult.afternoon += item.Value.afternoon;
                allPriceResult.evening += item.Value.evening;
            }
            return result;
        }

        /// <summary>
        /// 拼多多报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableAuditing]
        public async Task<Dictionary<string, PriceResult>> GetPDDPriceChangeByDay(IFormFile file)
        {
            //return await GetPriceChangeByDay(file, "订单成交时间", "商家实收金额(元)");

            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            //筛选售后订单
                            if ((Convert.ToString(item["订单状态"]) == "已签收"
                                || Convert.ToString(item["订单状态"]) == "已发货，待签收"
                                ) &&
                                    Convert.ToString(item["售后状态"]) == "无售后或售后取消"
                                    )
                            {
                                list.Add(new TaobaoSaleModel
                                {
                                    date = Convert.ToDateTime(item["订单成交时间"]),
                                    price = Convert.ToDouble(item["商家实收金额(元)"])
                                });
                            }
                        }
                        catch
                        {
                            errorcount++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            Console.WriteLine(errorcount);
            Console.WriteLine(errorcount);
            PriceResult allPriceResult = new PriceResult();
            foreach (var item in result)
            {
                allPriceResult.morning += item.Value.morning;
                allPriceResult.afternoon += item.Value.afternoon;
                allPriceResult.evening += item.Value.evening;
            }
            return result;
        }

        /// <summary>
        /// 抖店报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableAuditing]
        [AbpAllowAnonymous]
        public async Task<Dictionary<string, PriceResult>> GetDouDianPriceChangeByDay(IFormFile file,string channelName)
        {
            //return await GetPriceChangeByDay(file, "支付完成时间", "商品单价");
            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        if (Convert.ToString(item["售后状态"]) != "退款成功")
                        {
                            try
                            {
                                if (channelName.IsNullOrEmpty() || (Convert.ToString(item["达人昵称"]) == channelName))
                                {
                                    if ((Convert.ToString(item["订单状态"]) == "已完成"
                                    ) &&
                                        Convert.ToString(item["售后状态"]) != "退款成功"
                                        )
                                    {
                                        list.Add(new TaobaoSaleModel
                                        {
                                            date = Convert.ToDateTime(item["支付完成时间"]),
                                            price = Convert.ToDouble(item["商品单价"])
                                        });
                                    }
                                }
                            }
                            catch
                            {
                                errorcount++;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            Console.WriteLine(errorcount);
            Console.WriteLine(errorcount);
            PriceResult allPriceResult = new PriceResult();
            foreach (var item in result)
            {
                allPriceResult.morning += item.Value.morning;
                allPriceResult.afternoon += item.Value.afternoon;
                allPriceResult.evening += item.Value.evening;
            }
            return result;
        }


        /// <summary>
        /// 快手报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableAuditing]
        [AbpAllowAnonymous]

        public async Task<Dictionary<string, PriceResult>> GetKuaiShouPriceChangeByDay(IFormFile file)
        {
            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            //筛选售后订单
                            if (Convert.ToString(item["订单状态"]) == "交易成功" &&
                                    Convert.ToString(item["售后状态"]) != "退款成功"
                                    )
                            {
                                list.Add(new TaobaoSaleModel
                                {
                                    date = Convert.ToDateTime(item["订单创建时间"]),
                                    price = Convert.ToDouble(Convert.ToString(item["实付款"]).Replace("¥", ""))
                                });
                            }
                        }
                        catch
                        {
                            errorcount++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            PriceResult allPriceResult = new PriceResult();
            foreach (var item in result)
            {
                allPriceResult.morning += item.Value.morning;
                allPriceResult.afternoon += item.Value.afternoon;
                allPriceResult.evening += item.Value.evening;
            }
            return result;
        }

        /// <summary>
        /// 小红书报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableAuditing]
        [AbpAllowAnonymous]
        public async Task<Dictionary<string, PriceResult>> GetXiaoHongShuPriceChangeByDay(IFormFile file)
        {
            var result = new Dictionary<string, PriceResult>();
            var errorcount = 0;
            if (file.Length > 0)
            {
                var list = new List<TaobaoSaleModel>();
                DataTable dt = new DataTable();
                dt = NPOIExtensions.ExcelToDatatable(file.OpenReadStream(), Path.GetExtension(file.FileName), out string strMsg);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        try
                        {
                            if (Convert.ToString(item["订单状态"]) == "已完成"
                                && (
                                Convert.ToString(item["售后状态"]) == "无售后"
                                || Convert.ToString(item["售后状态"]) == "取消售后"
                                || Convert.ToString(item["售后状态"]) == "售后关闭"
                                || Convert.ToString(item["售后状态"]) == "售后拒绝"
                                )
                                )
                                list.Add(new TaobaoSaleModel
                                {
                                    date = Convert.ToDateTime(item["支付时间"]),
                                    price = Convert.ToDouble(item["商家实收金额(元)（支付金额）"])
                                });

                        }
                        catch
                        {
                            errorcount++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("没数据");
                }

                var list2 = list.GroupBy(e => e.date.Date).ToList();
                foreach (var item in list.OrderBy(e => e.date.Date).GroupBy(e => e.date.Date))
                {
                    result.Add(item.Key.ToString(), new PriceResult
                    {
                        morning = item.Where(e => dspMorningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspMorningEnd).Sum(e => e.price),
                        afternoon = item.Where(e => dspAfternoonBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspAfternoonEnd).Sum(e => e.price),
                        evening = item.Where(e => dspEveningBegin < Convert.ToDateTime(e.date).TimeOfDay && Convert.ToDateTime(e.date).TimeOfDay < dspEveningEnd).Sum(e => e.price)
                    });
                }
            }
            PriceResult allPriceResult = new PriceResult();
            foreach (var item in result)
            {
                allPriceResult.morning += item.Value.morning;
                allPriceResult.afternoon += item.Value.afternoon;
                allPriceResult.evening += item.Value.evening;
            }
            return result;
        }

        /// <summary>
        /// 统计汇总所有平台报表统计
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [DisableAuditing]
        [AbpAllowAnonymous]
        public async Task<Dictionary<string, PriceResult>> GetAllPriceChangeByDay(IFormFile tbfile, IFormFile pddfile, IFormFile dyfile, IFormFile ksfile, IFormFile xhsfile, IFormFile channelfile1,string channelName, IFormFile channelfile2)
        {
            var result = new Dictionary<string, PriceResult>();
            if (!tbfile.IsNull())
            {
                var tbresult = await GetTaoBaoPriceChangeByDay(tbfile);
                foreach (var item in tbresult)
                {
                    if (result.ContainsKey(item.Key))
                    {
                        result[item.Key].morning += item.Value.morning;
                        result[item.Key].afternoon += item.Value.afternoon;
                        result[item.Key].evening += item.Value.evening;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }

            if (!pddfile.IsNull())
            {
                var pddresult = await GetPDDPriceChangeByDay(pddfile);
                foreach (var item in pddresult)
                {
                    if (result.ContainsKey(item.Key))
                    {
                        result[item.Key].morning += item.Value.morning;
                        result[item.Key].afternoon += item.Value.afternoon;
                        result[item.Key].evening += item.Value.evening;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }
            if (!dyfile.IsNull())
            {
                var dyresult = await GetDouDianPriceChangeByDay(dyfile,channelName);
                foreach (var item in dyresult)
                {
                    if (result.ContainsKey(item.Key))
                    {
                        result[item.Key].morning += item.Value.morning;
                        result[item.Key].afternoon += item.Value.afternoon;
                        result[item.Key].evening += item.Value.evening;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }
            if (!ksfile.IsNull())
            {
                var ksresult = await GetKuaiShouPriceChangeByDay(ksfile);
                foreach (var item in ksresult)
                {
                    if (result.ContainsKey(item.Key))
                    {
                        result[item.Key].morning += item.Value.morning;
                        result[item.Key].afternoon += item.Value.afternoon;
                        result[item.Key].evening += item.Value.evening;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }

            }
            if (!xhsfile.IsNull())
            {
                var xhsresult = await GetXiaoHongShuPriceChangeByDay(xhsfile);
                foreach (var item in xhsresult)
                {
                    if (result.ContainsKey(item.Key))
                    {
                        result[item.Key].morning += item.Value.morning;
                        result[item.Key].afternoon += item.Value.afternoon;
                        result[item.Key].evening += item.Value.evening;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }
            if (!channelfile1.IsNull())
            {
                var channelresult = await GetChannelShopPriceChangeByDay(channelfile1,channelName);
                foreach (var item in channelresult)
                {
                    if (result.ContainsKey(item.Key))
                    {
                        result[item.Key].morning += item.Value.morning;
                        result[item.Key].afternoon += item.Value.afternoon;
                        result[item.Key].evening += item.Value.evening;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }
            if (!channelfile2.IsNull())
            {
                var channelresult = await GetChannelShopPriceChangeByDay(channelfile2, channelName);
                foreach (var item in channelresult)
                {
                    if (result.ContainsKey(item.Key))
                    {
                        result[item.Key].morning += item.Value.morning;
                        result[item.Key].afternoon += item.Value.afternoon;
                        result[item.Key].evening += item.Value.evening;
                    }
                    else
                    {
                        result.Add(item.Key, item.Value);
                    }
                }
            }

            PriceResult allPriceResult = new PriceResult();
            foreach(var item in result)
            {
                allPriceResult.morning += item.Value.morning;
                allPriceResult.afternoon += item.Value.afternoon;
                allPriceResult.evening += item.Value.evening;
            }

            result = result.OrderBy(kep => Convert.ToDateTime(kep.Key)).ToDictionary(kvp=>kvp.Key,kvp=>kvp.Value);

            result.Add("All", allPriceResult);

            return result;
        }

        public class TaobaoSaleModel
        {
            public double price { get; set; }

            public DateTime date { get; set; }
        }

        /// <summary>
        /// 获取销售件数
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerIgnore]
        public async Task<Dictionary<int, int>> GetSaleCount(AllOrderDto dto)
        {

            var dic = new Dictionary<int, int>();
            var result = await GetAllOrderList(dto);
            var temp = result.Select(e => e.order_detail.product_infos).CountIEnumerable();
            var temp2 = temp.GroupBy(e => e.product_id);
            foreach (var item in temp2)
            {
                dic.Add(item.Key, item.Count());
            }
            return dic;
        }

        public class PriceResult
        {
            public double morning { get; set; }

            public double afternoon { get; set; }

            public double evening { get; set; }
        }

        public class ChangeItem
        {
            /// <summary>
            /// 实际开播日期
            /// </summary>
            public string sourcetime { get; set; }

            public ChangeType sourceType { get; set; }

            /// <summary>
            /// 原定开播日期（需要交换）
            /// </summary>
            public string desttime { get; set; }
        }

        public enum ChangeType
        {
            Morning = 1,
            Afternoon = 2,
            Evening = 3
        }
    }
}
