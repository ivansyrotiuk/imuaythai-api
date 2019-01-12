namespace IMuaythai.Models.Licenses
{
    public class PaymentStatus
    {
        public int p24_merchant_id { get; set; }
        public string p24_session_id { get; set; }
        public int p24_amount { get; set; }
        public int p24_order_id { get; set; }
        public int p24_pos_id { get; set; }
        public int p24_method { get; set; }
        public string p24_statement { get; set; }
        public string p24_currency { get; set; }
        public string p24_sign { get; set; }
    }
}