using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        public IActionResult Index()
        {
            var version = Microsoft.Extensions.PlatformAbstractions.PlatformServices.Default.Application.ApplicationVersion;
            return Ok(version);
        }
    }
}