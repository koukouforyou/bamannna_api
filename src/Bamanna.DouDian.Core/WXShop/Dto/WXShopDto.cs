using System;
using System.Collections.Generic;
using System.Text;

namespace Bamanna.DouDian.WXShop.Dto
{
    public class WXShopDto
    {

    }

    public class OrderRequest
    {
        public string start_create_time { get; set; }
        public string end_create_time { get; set; }
        public int status { get; set; }
        public int page { get; set; }
        public int page_size { get; set; }
        public int source { get; set; }
    }

    public class SearchOrderRequest
    {
        public string start_pay_time { get; set; }
        public string end_pay_time { get; set; }
        public string title { get; set; }
        public string sku_code { get; set; }
        public string user_name { get; set; }
        public string tel_number { get; set; }
        public int? on_aftersale_order_exist { get; set; }
        public int? status { get; set; }
        public int? source { get; set; }
        public int? order_id { get; set; }
        public int? page { get; set; }
        public int? page_size { get; set; }
    }


    public class BatchGetAfterSaleOrderRequest
    {
        public long[] after_sale_order_id_list { get; set; }
    }

    public class WXShopResponse
    {
        public int errcode { get; set; }
        public string errmsg { get; set; }
    }


    public class BatchGetAfterSaleOrderResponse
    {
        public string errmsg { get; set; }
        public After_Sale_Order_List[] after_sale_order_list { get; set; }
    }

    public class After_Sale_Order_List
    {
        public long order_id { get; set; }
        public string status { get; set; }
        public string openid { get; set; }
        public long original_order_id { get; set; }
        public Product_Info product_info { get; set; }
        public Details details { get; set; }
        public Refund_Info refund_info { get; set; }
        public Return_Info return_info { get; set; }
        public Merchant_Upload_Info merchant_upload_info { get; set; }
        public long create_time { get; set; }
        public long update_time { get; set; }
        public string reason { get; set; }
        public Refund_Resp refund_resp { get; set; }
        public string type { get; set; }
    }

    public class Product_Info
    {
        public int product_id { get; set; }
        public int sku_id { get; set; }
        public int count { get; set; }
    }

    public class Details
    {
        public int num { get; set; }
        public string desc { get; set; }
        public int time { get; set; }
        public int receive_product { get; set; }
        public int cancel_time { get; set; }
        public object[] prove_imgs { get; set; }
        public string tel_number { get; set; }
    }

    public class Refund_Info
    {
        public int amount { get; set; }
    }

    public class Return_Info
    {
        public string waybill_id { get; set; }
        public string delivery_id { get; set; }
        public string delivery_name { get; set; }
    }

    public class Merchant_Upload_Info
    {
        public string reject_reason { get; set; }
        public object[] refund_certificates { get; set; }
    }

    public class Refund_Resp
    {
        public string code { get; set; }
        public int ret { get; set; }
        public string message { get; set; }
    }



    public class OrderResponse : WXShopResponse
    {
        public Order[] orders { get; set; }
        public int total_num { get; set; }
    }

    public class Order
    {
        public long order_id { get; set; }
        public string create_time { get; set; }
        public string update_time { get; set; }
        public int status { get; set; }
        public Order_Detail order_detail { get; set; }
        public Aftersale_Detail aftersale_detail { get; set; }
        public string openid { get; set; }
        public Ext_Info ext_info { get; set; }
        public int order_type { get; set; }
    }

    public class Order_Detail
    {
        public List<Product_Infos1> product_infos { get; set; }
        public Pay_Info pay_info { get; set; }
        public Price_Info price_info { get; set; }
        public Delivery_Info delivery_info { get; set; }
        public Coupon_Info coupon_info { get; set; }
    }

    public class Pay_Info
    {
        public string pay_method { get; set; }
        public string prepay_id { get; set; }
        public string prepay_time { get; set; }
        public string pay_time { get; set; }
        public string transaction_id { get; set; }
    }

    public class Price_Info
    {
        public int product_price { get; set; }
        public int order_price { get; set; }
        public int freight { get; set; }
        public int handing_fee { get; set; }
        public int max_unsplit_amount { get; set; }
    }

    public class Delivery_Info
    {
        public Address_Info address_info { get; set; }
        public string delivery_method { get; set; }
        public List<Express_Fee> express_fee { get; set; }
        public List<Delivery_Product_Info> delivery_product_info { get; set; }
        public int ship_done_time { get; set; }
        public Insurance_Info insurance_info { get; set; }
        public string deliver_type { get; set; }
        public int offline_delivery_time { get; set; }
        public int offline_pickup_time { get; set; }
        public int pickup_book_type { get; set; }
        public int pickup_address_id { get; set; }
        public object[] express_order_list { get; set; }
    }

    public class Address_Info
    {
        public string user_name { get; set; }
        public string postal_code { get; set; }
        public string province_name { get; set; }
        public string city_name { get; set; }
        public string county_name { get; set; }
        public string detail_info { get; set; }
        public string national_code { get; set; }
        public string tel_number { get; set; }
    }

    public class Insurance_Info
    {
        public string type { get; set; }
        public int insurance_price { get; set; }
    }

    public class Express_Fee
    {
        public int result { get; set; }
        public string shipping_method { get; set; }
    }

    public class Delivery_Product_Info
    {
        public string waybill_id { get; set; }
        public string delivery_id { get; set; }
        public Product_Infos[] product_infos { get; set; }
        public bool is_all_product { get; set; }
        public int delivery_time { get; set; }
        public string waybill_token { get; set; }
        public string delivery_name { get; set; }
        public string deliver_type { get; set; }
        public Delivery_Address delivery_address { get; set; }
    }

    public class Delivery_Address
    {
        public string user_name { get; set; }
        public string postal_code { get; set; }
        public string province_name { get; set; }
        public string city_name { get; set; }
        public string county_name { get; set; }
        public string detail_info { get; set; }
        public string national_code { get; set; }
        public string tel_number { get; set; }
    }

    public class Product_Infos
    {
        public int product_id { get; set; }
        public int sku_id { get; set; }
        public int product_cnt { get; set; }
    }

    public class Coupon_Info
    {
        public object[] coupon_id { get; set; }
    }

    public class Product_Infos1
    {
        public int product_id { get; set; }
        public int sku_id { get; set; }
        public string thumb_img { get; set; }
        public int sale_price { get; set; }
        public int sku_cnt { get; set; }
        public string title { get; set; }
        public List<Sku_Attrs> sku_attrs { get; set; }
        public int on_aftersale_sku_cnt { get; set; }
        public int finish_aftersale_sku_cnt { get; set; }
        public string sku_code { get; set; }
        public int market_price { get; set; }
    }

    public class Sku_Attrs
    {
        public string attr_key { get; set; }
        public string attr_value { get; set; }
    }

    public class Aftersale_Detail
    {
        public List<Aftersale_Order_List> aftersale_order_list { get; set; }
        public int on_aftersale_order_cnt { get; set; }
    }

    public class Aftersale_Order_List
    {
        public long aftersale_order_id { get; set; }
        public int status { get; set; }
    }


    public class Ext_Info
    {
        public string customer_notes { get; set; }
        public string merchant_notes { get; set; }
    }

}
