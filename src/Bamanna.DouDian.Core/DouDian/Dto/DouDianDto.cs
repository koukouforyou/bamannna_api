using System;
using System.Collections.Generic;
using System.Text;

namespace Bamanna.DouDian.DouDian.Dto
{
    public class DouDianDto
    {

    }

    //Package
    public class PackageListRequest
    {
        public int page { get; set; }
        public int pageSize { get; set; }
        public string order_by { get; set; }
    }

    public class PackageListResponse
    {
        public int code { get; set; }
        public Datum[] data { get; set; }
        public string msg { get; set; }
        public int offset { get; set; }
        public int page { get; set; }
        public int size { get; set; }
        public int st { get; set; }
        public int total { get; set; }
        public string error_level { get; set; }
    }

    public class Datum
    {
        public string logistics_company_code { get; set; }
        public string logistics_company_name { get; set; }
        public string tracking_no { get; set; }
        public Receiver_Info receiver_info { get; set; }
        public Order_List[] order_list { get; set; }
        public object[] buttons { get; set; }
        public string logistics_template_code { get; set; }
        public string logistics_template_name { get; set; }
        public int finish_fetch_tracking_no_time { get; set; }
        public int deliver_finish_time { get; set; }
        public object added_services { get; set; }
        public string[] added_services_description { get; set; }
        public object[] added_services_description_tag { get; set; }
    }

    public class Receiver_Info
    {
        public string post_receiver { get; set; }
        public string post_tel { get; set; }
        public Post_Addr post_addr { get; set; }
        public int can_view { get; set; }
        public int post_tel_type { get; set; }
        public int expire_time { get; set; }
        public bool is_show_edit_address { get; set; }
        public bool can_postpone { get; set; }
        public string extension_number { get; set; }
        public string post_tel_mask { get; set; }
        public object address_tag { get; set; }
        public object user_account_infos { get; set; }
    }

    public class Post_Addr
    {
        public Province province { get; set; }
        public City city { get; set; }
        public Town town { get; set; }
        public Street street { get; set; }
        public string detail { get; set; }
    }

    public class Province
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool has_child { get; set; }
    }

    public class City
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool has_child { get; set; }
    }

    public class Town
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool has_child { get; set; }
    }

    public class Street
    {
        public string name { get; set; }
        public string id { get; set; }
        public bool has_child { get; set; }
    }

    public class Order_List
    {
        public string order_id { get; set; }
        public string shop_order_id { get; set; }
        public int order_status { get; set; }
        public string user_id { get; set; }
        public int now_ts { get; set; }
        public int pay_type { get; set; }
        public int order_type { get; set; }
        public int b_type { get; set; }
        public int c_biz { get; set; }
        public int biz { get; set; }
        public int receive_type { get; set; }
        public int e_express { get; set; }
        public int repeat { get; set; }
        public int is_dup { get; set; }
        public int pre_receive_info_exist { get; set; }
        public bool has_write_off_record { get; set; }
        public int is_already_modify_amount { get; set; }
        public int user_is_auth { get; set; }
        public int can_modify_amount { get; set; }
        public int change_addr { get; set; }
        public string store_name { get; set; }
        public int wait_ship_count { get; set; }
        public int shipped_count { get; set; }
        public int product_count { get; set; }
        public int total_post_amount { get; set; }
        public int total_pay_amount { get; set; }
        public int pay_amount { get; set; }
        public int post_amount { get; set; }
        public int total_tax_amount { get; set; }
        public int total_include_tax_amount { get; set; }
        public int total_excluding_tax_amount { get; set; }
        public int total_goods_amount { get; set; }
        public int promotion_amount { get; set; }
        public int modify_amount { get; set; }
        public int modify_post_amount { get; set; }
        public int sku_modify_amount { get; set; }
        public int shop_receive_amount { get; set; }
        public int promotion_pay_amount { get; set; }
        public int envelope_promotion_amount { get; set; }
        public int create_time { get; set; }
        public int confirm_time { get; set; }
        public int pay_time { get; set; }
        public int logistics_time { get; set; }
        public int receipt_time { get; set; }
        public int group_time { get; set; }
        public int exp_ship_time { get; set; }
        public string order_type_desc { get; set; }
        public string pay_type_desc { get; set; }
        public object write_off_desc { get; set; }
        public string buyer_words { get; set; }
        public string remark { get; set; }
        public int star { get; set; }
        public string user_nickname { get; set; }
        public bool has_write_off { get; set; }
        public bool has_more { get; set; }
        public string pre_sale_desc { get; set; }
        public object receive_info { get; set; }
        public object receiver_info { get; set; }
        public object policy_info { get; set; }
        public Order_Status_Info order_status_info { get; set; }
        public object operation_actions { get; set; }
        public object action_map { get; set; }
        public object button { get; set; }
        public object order_bottom_card { get; set; }
        public Product_Item[] product_item { get; set; }
        public object shop_order_tag { get; set; }
        public object pay_amount_detail { get; set; }
        public string way_bill_url { get; set; }
        public int cross_border_send_type { get; set; }
        public object order_amount_card { get; set; }
        public string pay_amount_desc { get; set; }
        public string shop_receive_amount_desc { get; set; }
        public object serial_numbers { get; set; }
        public object[] address_tag { get; set; }
        public object support_detail { get; set; }
        public bool need_serial_number { get; set; }
        public string b_type_desc { get; set; }
        public string c_biz_desc { get; set; }
        public object price_detail { get; set; }
        public object promotion_detail { get; set; }
        public string pay_type_desc_hover { get; set; }
        public int manual_order_type { get; set; }
        public string order_id_for_show { get; set; }
        public object order_tag_stamp { get; set; }
        public object url_map { get; set; }
        public object user_profile_tag { get; set; }
    }

    public class Order_Status_Info
    {
        public int dead_line_time { get; set; }
        public int order_status_icon { get; set; }
        public string order_status_text { get; set; }
        public string order_status_remark { get; set; }
        public string order_status_over_remark { get; set; }
        public bool show_rule { get; set; }
        public string order_status_over_remark_v2 { get; set; }
        public bool is_appointment_ship { get; set; }
        public int appointment_ship_time { get; set; }
        public string appointment_ship_time_str { get; set; }
        public int cut_down_second { get; set; }
        public string order_status_remark_v2 { get; set; }
        public string ship_time_change_desc { get; set; }
        public string ship_time_change_hover { get; set; }
    }

    public class Product_Item
    {
        public string item_order_id { get; set; }
        public int order_status { get; set; }
        public string order_type { get; set; }
        public int pre_sale_type { get; set; }
        public int process_type { get; set; }
        public int biz { get; set; }
        public string price_has_tax_type { get; set; }
        public int c_biz { get; set; }
        public int total_amount { get; set; }
        public int post_amount { get; set; }
        public int tax_amount { get; set; }
        public string product_id { get; set; }
        public int sku_id { get; set; }
        public string merchant_sku_code { get; set; }
        public string product_name { get; set; }
        public string img { get; set; }
        public Sku_Spec[] sku_spec { get; set; }
        public int combo_amount { get; set; }
        public int combo_num { get; set; }
        public int shipped_count { get; set; }
        public string item_order_status_desc { get; set; }
        public string package_status_desc { get; set; }
        public object aftersale_service { get; set; }
        public object policy_info { get; set; }
        public After_Sale_Info after_sale_info { get; set; }
        public object tags { get; set; }
        public object promotion_detail { get; set; }
        public object sku_bundle_sub_skus { get; set; }
        public string item_warehouse_id { get; set; }
        public string item_warehouse_name { get; set; }
        public object action_map { get; set; }
        public object relation_order { get; set; }
        public int trade_type { get; set; }
        public int available_fetch_cnt { get; set; }
        public object properties { get; set; }
        public object sku_customization_info { get; set; }
    }

    public class After_Sale_Info
    {
        public int url_after_sale_no { get; set; }
        public string after_sale_text { get; set; }
        public string after_sale_remark { get; set; }
        public string after_sale_id { get; set; }
        public bool has_pre_sale { get; set; }
        public int aftersale_status_class_color_type { get; set; }
        public string aftersale_status_class_string { get; set; }
    }

    public class Sku_Spec
    {
        public string name { get; set; }
        public string value { get; set; }
    }


    //ReceiveInfo
    public class ReceiveInfoRequest
    {
        public string tracking_no { get; set; }
    }

    public class ReceiveInfoResponse
    {
        public int errno { get; set; }
        public int st { get; set; }
        public string msg { get; set; }
        public int code { get; set; }
        public Data data { get; set; }
        public int page { get; set; }
        public int total { get; set; }
        public int size { get; set; }
        public int total_page { get; set; }
    }

    public class Data
    {
        public string verify_type { get; set; }
        public object verify_params { get; set; }
        public int is_send { get; set; }
        public Receive_Info receive_info { get; set; }
        public object pre_receive_info { get; set; }
        public string nick_name { get; set; }
    }

    public class Receive_Info
    {
        public string post_receiver { get; set; }
        public long post_tel { get; set; }
        public Post_Addr post_addr { get; set; }
        public int can_view { get; set; }
        public int post_tel_type { get; set; }
        public int expire_time { get; set; }
        public bool is_show_edit_address { get; set; }
        public bool can_postpone { get; set; }
        public string extension_number { get; set; }
        public string post_tel_mask { get; set; }
        public object address_tag { get; set; }
        public object user_account_infos { get; set; }
    }
}
