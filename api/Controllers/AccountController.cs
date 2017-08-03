using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MuaythaiSportManagementSystemApi.Models;
using MuaythaiSportManagementSystemApi.Models.AccountModels;
using MuaythaiSportManagementSystemApi.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MuaythaiSportManagementSystemApi.Repositories;
using MuaythaiSportManagementSystemApi.Users;

namespace MuaythaiSportManagementSystemApi.Controllers
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
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IInstitutionsRepository institutionsRepository,
            IUserRoleRequestsRepository userRoleRequestsRepository,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory,
            IJwtTokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _institutionsRepository = institutionsRepository;
            _userRoleRequestsRepository = userRoleRequestsRepository;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _tokenGenerator = tokenGenerator;
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto model)
        {
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                _logger.LogInformation(1, "User logged in.");
                var roles = await _userManager.GetRolesAsync(user);

                string encodedToken = _tokenGenerator.GenerateToken(user, roles);

                return Ok(new { authToken = encodedToken, rememberMe = model.RememberMe });
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning(2, "User account locked out.");
                return BadRequest("User account locked out.");
            }
            else
            {
                return BadRequest("Invalid login or password");
            }
        }

        

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody]RegisterDto model)
        {

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = $"{model.CallbackUrl}?userid={user.Id}&code={code}";
             
                    await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                        $"Please confirm your account by clicking this link: <a href=\"{callbackUrl}\">link</a>");
                        
                    _logger.LogInformation(3, "User created a new account with password.");
                    return Created("Email confirmation sent", null);
                }
            

            // If we got this far, something failed, redisplay form
            return BadRequest(result.Errors.First().Description);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register/finish")]
        public async Task<IActionResult> FinishRegister([FromBody]FinishRegisterDto model)
        {
            try
            {
                string userId = User.GetUserId();
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                Institution gym = model.OwnGym == true ? new Institution
                {
                    Name = model.GymName,
                    CountryId = model.CountryId
                } : await _institutionsRepository.Get(model.InstitutionId.Value);

                if (model.OwnGym == true)
                {
                    await _institutionsRepository.Save(gym);
                }

                UserRoleRequest entity = new UserRoleRequest();
                entity.RoleId = model.RoleId;
                entity.UserId = userId;
                entity.Status = UserRoleRequestStatus.Pending;
                entity.InstitutionId = gym.Id;
                await _userRoleRequestsRepository.Save(entity);

                user.InstitutionId = gym.Id;
                user.CountryId = model.CountryId;

                
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

        //
        // POST: /Account/Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation(4, "User logged out.");
            return Ok();
        }


        // GET: /Account/ConfirmEmail
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
            if(result.Succeeded)
                return Ok("Email confirmed"); 

            return BadRequest("Something went wrong");
            
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [Route("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody]ForgotPasswordDto model)
        {

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return NotFound("User not found");
                }

                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
                // Send an email with this link
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = $"{model.CallbackUrl}?userid={user.Id}&code={code}";
             
                    await _emailSender.SendEmailAsync(model.Email, "Reset password",
                        $"Please reset your password by clicking this link: <a href=\"{callbackUrl}\">link</a>");

                return Ok("Reset password email sent");
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordDto model)
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

        [HttpGet]
        [AllowAnonymous]
        [Route("setup")]
        public async Task<ActionResult> SetupRoles()
        {
            List<string> rolesList = new List<string>
            {
                //"Admin",
                //"InstitutionAdmin",
                //"Fighter",
                //"Coach",
                //"Judge",
                //"Doctor",
                //"Guest",
                "NationalFederation",
                "ContinentalFederation",
                "WorldFederation",
            };

            foreach (var role in rolesList)
            {

                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = role
                });
            }

            //var user = await _userManager.FindByIdAsync("38920a18-ba62-49b6-a0b8-415cdd5a692c");
            //await _userManager.AddToRoleAsync(user, "Admin");
       
            //var roles = _roleManager.Roles.ToList();

            return Ok(rolesList);
        }
        
    }
}