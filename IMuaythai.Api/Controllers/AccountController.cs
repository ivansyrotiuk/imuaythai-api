using System.Threading.Tasks;
using IMuaythai.Auth;
using IMuaythai.Models.AccountModels;
using IMuaythai.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMuaythai.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginModel)
        {
            var result = await _authService.Login(loginModel);
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            await _authService.Register(model);
            return Ok("User has been registered");
        }

     
        [HttpPost]
        [AllowAnonymous]
        [Route("register/finish")]
        public async Task<IActionResult> FinishRegister([FromBody] FinishRegistrationModel model)
        {
            var token = await _authService.FinishRegistration(model);
            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserModel createUserModel)
        {
            var user = await _authService.CreateUser(createUserModel);
            return Ok(user);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("confirmemail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest("User or code is invalid");
            }

            await _authService.ConfirmEmail(userId, code);

            return Ok("Email confirmed");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {
            await _authService.ForgotPassword(model);
            return Ok("Reset password email sent");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            await _authService.ResetPassword(model);
            return Ok("Password resetted");
        }
    }
}
