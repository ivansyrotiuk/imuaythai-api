namespace IMuaythai.Licenses
{
    public class PaymentsConfiguration
    {
        public int MerchantId { get; set; }
        public int PosId { get; set; }
        public string UrlReturn { get; set; }
        public string UrlStatus { get; set; }
        public string CRC { get; set; }
        public string PaymentsUrl { get; set; }
    }
}