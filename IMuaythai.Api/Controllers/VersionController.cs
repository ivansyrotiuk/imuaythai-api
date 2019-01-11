using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IMuaythai.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IMuaythai.Api.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;
        private readonly IPayments24Client _payments24Client;

        public VersionController(ILoggerFactory loggerFactory, IEmailSender emailSender, IPayments24Client payments24Client)
        {
            _logger = loggerFactory.CreateLogger<VersionController>();
            _emailSender = emailSender;
            _payments24Client = payments24Client;
        }

        public IActionResult Index()
        {
            var version = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application
                .ApplicationVersion;
            return Ok(version);
        }

        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> PaymentCallbackPost([FromForm]PaymentStatus status)
        {
            try
            {
                var form = new Dictionary<string, object>
                {
                    {"p24_merchant_id", status.p24_merchant_id},
                    {"p24_pos_id", status.p24_pos_id},
                    {"p24_session_id", status.p24_session_id},
                    {"p24_amount", status.p24_amount},
                    {"p24_currency", status.p24_currency},
                    {"p24_order_id", status.p24_order_id},
                    {"p24_sign", status.p24_sign}
                };

                var response = await _payments24Client.Pay(form);

                Console.WriteLine(response.StringContent + response.ResponseMessage.StatusCode);
                _logger.Log(LogLevel.Error, response.StringContent + response.ResponseMessage.StatusCode);


                var s = Newtonsoft.Json.JsonConvert.SerializeObject(status);
                Console.WriteLine(s);
                await _emailSender.SendEmailAsync("waserdx@gmail.com", "test payment", s);
                _logger.Log(LogLevel.Error, s);

                return Ok(status);
            }
            catch (Exception ex)
            {
                var s = Newtonsoft.Json.JsonConvert.SerializeObject(status);

                await _emailSender.SendEmailAsync("waserdx@gmail.com", "test payment", ex.ToString());
                Console.WriteLine(ex);

                throw;
            }
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
}