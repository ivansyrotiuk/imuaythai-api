using System.Threading.Tasks;
using IMuaythai.Dashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Route("api/[controller]")]
    public class DashboardController: Controller
    {
        private readonly IContestEventsService _contestEventsService;

        public DashboardController(IContestEventsService contestEventsService)
        {
            _contestEventsService = contestEventsService;
        }

        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetContestEvents()
        {
            var events = await _contestEventsService.GetContestEvents();
            return Ok(events);
        }
    }
}
