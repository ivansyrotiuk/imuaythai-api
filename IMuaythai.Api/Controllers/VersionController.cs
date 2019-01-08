using System;
using System.IO;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IMuaythai.Api.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        private readonly ILogger _logger;

        public VersionController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<VersionController>();
        }

        public IActionResult Index()
        {
            var version = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application
                .ApplicationVersion;
            return Ok(version);
        }

        [HttpGet]
        [Route("pay")]
        public IActionResult PaymentCallback()
        {
            using (StreamReader stream = new StreamReader(HttpContext.Request.Body))
            {
                string body = stream.ReadToEnd();
                Console.WriteLine(body);
                Console.WriteLine(Request.QueryString);
                _logger.Log(LogLevel.Critical, body);
                throw new Exception(body + "- " + Request.QueryString);
            }

            return Ok();
        }

        [HttpPost]
        [Route("pay")]
        public IActionResult PaymentCallbackPost([FromBody]PaymentStatus status)
        {
            var s = Newtonsoft.Json.JsonConvert.SerializeObject(status);
           
            Console.WriteLine(s);
            _logger.Log(LogLevel.Error, s);

            WebClient b = new WebClient();
            b.UploadString("http://demo1871308.mockable.io/", s);

            return Ok(status);
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