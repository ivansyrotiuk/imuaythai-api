namespace IMuaythai.Licenses
{
    public class LicensePayment
    {
        public int SessionId { get; set; }
        public int MerchantId { get; set; }
        public int PosId { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public string UrlReturn { get; set; }
        public string UrlStatus { get; set; }
        public string PaymentsUrl { get; set; }
        public string Sign { get; set; }
        public string Country { get; set; }
    }
}