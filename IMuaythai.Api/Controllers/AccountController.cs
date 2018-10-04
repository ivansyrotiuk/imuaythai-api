using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Auth;
using IMuaythai.DataAccess.Models;
using IMuaythai.HttpServices;
using IMuaythai.Models.AccountModels;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;
using IMuaythai.Services;
using IMuaythai.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IMuaythai.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IInstitutionsRepository _institutionsRepository;
        private readonly IUserRoleRequestsRepository _userRoleRequestsRepository;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IUsersService _usersService;
        private readonly IHostingEnvironment _hostingEnvironment;


        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IInstitutionsRepository institutionsRepository,
            IUserRoleRequestsRepository userRoleRequestsRepository,
            IEmailSender emailSender,
            ILoggerFactory loggerFactory,
            IJwtTokenGenerator tokenGenerator,
            IUsersService usersService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _institutionsRepository = institutionsRepository;
            _userRoleRequestsRepository = userRoleRequestsRepository;
            _emailSender = emailSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _tokenGenerator = tokenGenerator;
            _usersService = usersService;

            foreach (DictionaryEntry variable in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"Var={variable.Key}: {variable.Value}");
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,
                lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                if (!result.IsLockedOut)
                {
                    return BadRequest("Invalid login or password");
                }

                _logger.LogWarning("User account locked out.");
                return BadRequest("User account locked out.");
            }

            var user = await _userManager.FindByEmailAsync(model.Email) ??
                       await _userManager.FindByNameAsync(model.Email);

            _logger.LogInformation($"User {model.Email} logged in.");
            var roles = await _userManager.GetRolesAsync(user);

            var encodedToken = _tokenGenerator.GenerateToken(user, roles);
            return Ok(new LoginResponseModel
            {
                AuthToken = encodedToken,
                RememberMe = model.RememberMe,
                QrCode = string.Empty,
                User = new AutorizedUserResponseModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    Surname = user.Surname
                }
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.First().Description);
            }

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackLink = MakeCallbackLink(model.CallbackUrl, user, code, "activation link");

            await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                $"Please confirm your account go to this link: {callbackLink}");

            _logger.LogInformation("User created a new account with password.");
            return Ok("Email confirmation sent");
        }

        private static string MakeCallbackLink(string baseUrl, ApplicationUser user, string code, string text)
        {
            if (!baseUrl.Contains("/#/"))
            {
                var lastSlash = baseUrl.LastIndexOf("/", StringComparison.InvariantCulture);
                baseUrl = baseUrl.Insert(lastSlash, "/#");
            }

            var callbackUrl = $"{baseUrl}?userid={user.Id}&code={code}";
            return $"<a href=\"{callbackUrl}\">{text}</a>";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register/finish")]
        public async Task<IActionResult> FinishRegister([FromBody] FinishRegistrationModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(User.GetUserId());
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                Institution gym;
                if (model.OwnGym == true)
                {
                    gym = new Institution
                    {
                        Name = model.GymName,
                        CountryId = model.CountryId
                    };
                    await _institutionsRepository.Save(gym);
                }
                else
                {
                    gym = await _institutionsRepository.Get(model.InstitutionId.Value);
                }

                var entity = new UserRoleRequest
                {
                    RoleId = model.RoleId,
                    UserId = User.GetUserId(),
                    Status = UserRoleRequestStatus.Pending,
                    InstitutionId = gym.Id
                };
                await _userRoleRequestsRepository.Save(entity);

                user.InstitutionId = gym.Id;
                user.CountryId = model.CountryId;
                user.Surname = model.Surname;
                user.FirstName = model.FirstName;

                await _userManager.UpdateAsync(user);
                await _userManager.AddToRoleAsync(user, "Guest");
                var roles = await _userManager.GetRolesAsync(user);
                var token = _tokenGenerator.GenerateToken(user, roles);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return Ok();
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserModel createUserModel)
        {
            try
            {
                var user = await _usersService.CreateUser(createUserModel);
                var request = HttpContext.Request;
                await _emailSender.SendEmailAsync(createUserModel.Email, "Imuaythai",
                    $"Your IMuaythai account is ready. Go to <a href=\"{request.Scheme}://{request.Host.ToUriComponent()}\">IMuaythai</a>");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return Ok("Email confirmed");

            return BadRequest("Something went wrong");

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto model)
        {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                return NotFound("User not found");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackLink = MakeCallbackLink(model.CallbackUrl, user, code, "link");

            await _emailSender.SendEmailAsync(model.Email, "Reset password",
                $"Please reset your password by clicking this link: {callbackLink}");

            return Ok("Reset password email sent");
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return NotFound("User not found");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return Ok("Password resetted");
            }

            return BadRequest("Can't reset password");
        }
    }
}
