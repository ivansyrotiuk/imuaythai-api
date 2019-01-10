using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IMuaythai.Payments.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IPayments24Client _payments24Client;

        public HomeController(ILoggerFactory loggerFactory,  IPayments24Client payments24Client)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
            _payments24Client = payments24Client;
        }

        public IActionResult Index()
        {
            Console.WriteLine(Request.QueryString.ToString());
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(PaymentStatus status)
        {
            try
            {

                await _payments24Client.Pay(new Dictionary<string, string>
                {
                    {"p24_merchant_id", status.p24_merchant_id.ToString()},
                    {"p24_pos_id", status.p24_pos_id.ToString()},
                    {"p24_session_id", status.p24_session_id},
                    {"p24_amount", status.p24_amount.ToString()},
                    {"p24_currency", status.p24_currency},
                    {"p24_order_id", status.p24_order_id.ToString()},
                    {"p24_sign", PaymentSigner.Sign(status.p24_session_id, status.p24_order_id, status.p24_amount, status.p24_currency, "b5c0e98687b0f43d")}
                });


                var s = Newtonsoft.Json.JsonConvert.SerializeObject(status);
                Console.WriteLine(s);
                _logger.Log(LogLevel.Error, s);
            }
            catch (Exception ex)
            {
                var s = Newtonsoft.Json.JsonConvert.SerializeObject(status);

                Console.WriteLine(ex);

                throw;
            }
            return View();
        }
    }

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

    public static class PaymentSigner
    {
        public static string Sign(string sessionId, int orderId, int amount, string currency, string crc)
        {
            using (var md5 = MD5.Create())
            {
                var input = $"{sessionId}|{orderId}|{amount}|{currency}|{crc}";
                var result = string.Join("", md5.ComputeHash(Encoding.ASCII.GetBytes(input)).Select(x => x.ToString("X2")));
                return result;
            }
        }
    }
}
