using Bamanna.DouDian.Api;
using Bamanna.DouDian.WXShop.Dto;
using Bamanna.DouDian.WXShop.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.WXShop
{
    public class WXShopManager: ApiManagerBase,IWXShopManager
    {
        private readonly IWXShopApiManager _wXShopApiManager;
        public WXShopManager(IWXShopApiManager wXShopApiManager)
        {
            _wXShopApiManager = wXShopApiManager;
        }

        public async Task<OrderResponse> GetOrderList(OrderRequest body)
        {
            return await _wXShopApiManager.HttpRequest<OrderResponse, OrderRequest>("https://api.weixin.qq.com/product/order/get_list", null, body, HttpMethod.Post);
        }

        public async Task<OrderResponse> SearchOrderList(SearchOrderRequest body)
        {
            return await _wXShopApiManager.HttpRequest<OrderResponse, SearchOrderRequest>("https://api.weixin.qq.com/product/order/search", null, body, HttpMethod.Post);
        }

        public async Task<BatchGetAfterSaleOrderResponse> BatchGetAfterSaleOrder(BatchGetAfterSaleOrderRequest body)
        { 
            return await _wXShopApiManager.HttpRequest<BatchGetAfterSaleOrderResponse, BatchGetAfterSaleOrderRequest>("https://api.weixin.qq.com/product/order/batchgetaftersaleorder", null, body, HttpMethod.Post);
        }
    }
}
