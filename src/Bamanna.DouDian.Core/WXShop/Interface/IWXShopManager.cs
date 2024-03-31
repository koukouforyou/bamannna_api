using Bamanna.DouDian.Api;
using Bamanna.DouDian.WXShop.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.WXShop.Interface
{
    public interface IWXShopManager : IApiManagerBase
    {
        Task<OrderResponse> GetOrderList(OrderRequest body);

        Task<OrderResponse> SearchOrderList(SearchOrderRequest body);

        Task<BatchGetAfterSaleOrderResponse> BatchGetAfterSaleOrder(BatchGetAfterSaleOrderRequest body);
    }
}
