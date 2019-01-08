using System;
using System.IO;
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
        public IActionResult PaymentCallbackPost()
        {
            using (StreamReader stream = new StreamReader(Request.Body))
            {
                string body = stream.ReadToEnd();
                Console.WriteLine(body);
                Console.WriteLine(Request.QueryString);
                _logger.Log(LogLevel.Critical, body);
                throw  new Exception(body + "- " + Request.QueryString);
            }

            return Ok();
        }
    }
}