using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.HttpServices;
using IMuaythai.Licenses;
using IMuaythai.Models.Licenses;
using IMuaythai.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Authorize]
    [Route("api/Licenses")]
    public class LicensesController : Controller
    {
        private readonly IHttpUserContext _userContext;
        private readonly ILicenseService _licenseService;
        private readonly ILicensePaymentService _licensePaymentService;
        private readonly ILicenseTypesService _licenseTypesService;

        public LicensesController(IEmailSender emailSender, ILicenseService licenseService, ILicensePaymentService licensePaymentService, IHttpUserContext userContext, ILicenseTypesService licenseTypesService)
        {
            _licenseService = licenseService;
            _licensePaymentService = licensePaymentService;
            _userContext = userContext;
            _licenseTypesService = licenseTypesService;
        }

        [HttpGet]
        [Route("create")]
        public async Task<IActionResult> CreateLicense(int licenseTypeId, int institutionId)
        {
            var userId = _userContext.GetUserId();
            var license = await _licenseService.CreateLicense(licenseTypeId, userId, institutionId);
            return Ok(license);
        }

        [HttpGet]
        [Route("payment")]
        public async Task<IActionResult> GetPayment([FromQuery]int licenseId)
        {
            var user = await _userContext.GetUser();
            var payment = await _licensePaymentService.GetPayment(licenseId, user);
            return Ok(payment);
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("payment/confirm")]
        public async Task<IActionResult> ConfirmPayment([FromForm]PaymentStatus status)
        {
            await _licensePaymentService.ConfirmPayment(status);
            return Ok();
        }

        [HttpGet]
        [Route("types")]
        public async Task<IActionResult> GetLicenseTypes()
        {
            var user = await _userContext.GetUser();
            var types = await _licenseTypesService.GetLicenseTypes(user);
            return Ok(types);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("types/create")]
        public async Task<IActionResult> CreateTypes()
        {
            await _licenseTypesService.CreateLicenseTypes();
            return Ok();
        }
    }
}