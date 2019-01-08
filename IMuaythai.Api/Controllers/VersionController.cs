using System;
using System.IO;
using System.Net;
using System.Reflection;
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

        public VersionController(ILoggerFactory loggerFactory, IEmailSender emailSender)
        {
            _logger = loggerFactory.CreateLogger<VersionController>();
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            var version = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application
                .ApplicationVersion;
            return Ok(version);
        }

        [HttpGet]
        [Route("pay")]
        public async Task<IActionResult> PaymentCallback([FromQuery]PaymentStatus status)
        {
            try
            {
                var s = Newtonsoft.Json.JsonConvert.SerializeObject(status);

                await _emailSender.SendEmailAsync("waserdx@gmail.com", "test payment", s);
                Console.WriteLine(s);
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

        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> PaymentCallbackPost([FromBody]PaymentStatus status)
        {
            try
            {
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
}