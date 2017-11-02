using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.Api.Services;
using IMuaythai.Api.Users;
using IMuaythai.DataAccess.Models;
using IMuaythai.DataAccess.Models.AccountModels;
using IMuaythai.Repositories;
using Microsoft.AspNetCore.Authorization;
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
                if (user == null)
                {
                    user = await _userManager.FindByNameAsync(model.Email);
                }

                _logger.LogInformation(1, "User logged in.");
                var roles = await _userManager.GetRolesAsync(user);

                string encodedToken = _tokenGenerator.GenerateToken(user, roles);
                var u = new { authToken = encodedToken, rememberMe = model.RememberMe, user = new { id = user.Id, firstName = user.FirstName, surname = user.Surname } };
                var qr = QRCodeGenerator.GenerateQRCode(u);
                return Ok(new { authToken = encodedToken, rememberMe = model.RememberMe, qrcode = qr, user = new { id = user.Id, firstName = user.FirstName, surname = user.Surname } });
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

                Institution gym;
                if (model.OwnGym != true)
                {
                    gym = await _institutionsRepository.Get(model.InstitutionId.Value);
                }
                else
                {
                    gym = new Institution
                    {
                        Name = model.GymName,
                        CountryId = model.CountryId
                    };
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
            if (result.Succeeded)
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
                //"NationalFederation",
                //"ContinentalFederation",
                //"WorldFederation",
            };

            foreach (var role in rolesList)
            {

                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = role
                });
            }

            var user = await _userManager.FindByIdAsync(User.GetUserId());
            await _userManager.AddToRoleAsync(user, "Admin");

            var roles = _userManager.GetRolesAsync(user);

            return Ok(rolesList);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("setup_roles")]
        public async Task<ActionResult> SetupUserRoles()
        {
            var fighters = await _userManager.GetUsersInRoleAsync("Fighter");
            var fightersIds = fighters.Select(f => f.Id);
            var users = _userManager.Users.Where(u => !fightersIds.Contains(u.Id)).ToList();
            foreach (var user in users)
            {
                await _userManager.AddToRoleAsync(user, "Fighter");
            }

            return Ok(users);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("setup_users")]
        public async Task<ActionResult> SetupUsers()
        {
            var fightersIndentities = new Dictionary<string, string>
            {
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Khaosai Galaxy" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge George Dixon" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Bob Fitzsimmons" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Tony Zale" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Ricardo Lopez" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Carlos Ortiz" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Manuel Ortiz" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Sonny Liston" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Wilfred Benitez" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Wilfredo Gomez" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Barbados Walcott" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Bob Foster" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Fighting Harada" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Pancho Villa" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Lennox Lewis" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Abe Attell" },
                { Guid.NewGuid().ToString() + "@judge.com", "Judge Johnny Dundee" },

            };

            foreach (var f in fightersIndentities)
            {
                ApplicationUser user = new ApplicationUser
                {
                    InstitutionId = 12,
                    Email = f.Key,
                    FirstName = f.Value.Split(' ')[0],
                    Surname = f.Value.Split(' ')[1],
                    UserName = f.Value.Replace(" ", ""),
                    CountryId = 177
                };

                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, "Judge");
            }

            return Ok(fightersIndentities);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("set_pass")]
        public async Task<IActionResult> SetPasswords()
        {
            string[] ids = new string[]
            {
                "024e3f7c-ebf8-47d7-b806-5acc438963a3",
"030d83a7-1a41-4f97-874f-fc57fe46fbe3",
"182d2464-c6e6-49e7-b62c-1d720afaab00",
"1845a72b-7036-480f-bfd4-52a7922189cf",
"21368501-6d06-4c42-b1de-db86eb8c29f0",
"22e7861a-7a74-4fdf-bdc9-da0667fa1dac",
"244dbb95-9f75-42f9-8d41-6969b74cc0d0",
"2452245a-633f-49d1-a5de-a3e8440c1c60",
"25820b55-3d3c-4d61-ae8b-1874d148adb1",
"2d687b97-497a-4f90-8456-39d42fc9d432",
"316b8293-abc8-494e-8f23-256fb6a80bf9",
"38ec3e6e-ef29-49c4-9b10-51cd275af259",
"46000768-a837-4f14-a8c9-85ad779dd735",
"4c572e8a-7ec0-469c-bf19-17dd77652f20",
"57458cbc-2d8a-46fe-bc95-0be93b975315",
"5c04e55e-2b83-44ae-9e2a-d7f5bf3eb6cd",
"5dee90b7-b428-4498-9fbe-6d0cca537bee",
"5ee6660e-8d44-4d0d-9630-ef3c17a942bb",
"60b2ceb3-81ff-48a6-b258-0170f26bcc3b",
"62239beb-19a5-4c3c-a0db-55a5c99dc0dd",
"65f09a8a-028a-48ad-a9fd-21a1642f790f",
"6ee92052-852c-41ff-a16f-16e32bd61de8",
"6f3b381a-2cb2-4504-80c5-66ab6600505c",
"77f4ca6d-f458-45b8-80f7-9cb34aaddb46",
"7d4bafe4-74fd-4c91-9693-e7bbf3f2c9e1",
"84e60a3f-3de9-4903-b3ef-6a94d330a508",
"8baed8f4-de57-4984-b23c-45bbfc1a3b7c",
"8de7e3a3-efb7-4b52-a2f8-ec453f132ab1",
"9191a741-7971-4b00-bbc1-2ddcc9121287",
"922ac6a2-97da-4f74-8d70-d179713bf5e7",
"93537d65-db87-4194-91f8-f65028e42dda",
"94bc761b-be69-4baf-9469-15d70d4975df",
"952d9a23-3c0c-4910-ab76-0be686c5a966",
"9b32e8cf-e5c9-4a33-b8d1-e1145ec936de",
"a572096e-948c-452c-b4e7-b0421ec94f91",
"a7d3e0da-e470-40a3-9f61-d3f4fbe866ba",
"ad5dc404-0bb4-4469-a7c4-56c2a2fec5e0",
"aec2e9e1-e71a-4c5e-90fb-beeb8940aba4",
"b01fec54-100f-42d2-9f72-c5017c205804",
"b0fe523c-cdf5-45b6-b929-eb0a9635cafb",
"b4cfd633-fbc6-4ad2-912f-ff95310c40ed",
"c175dfaf-04de-408c-a868-aa386ee27bcf",
"c53a5c37-28d3-4877-a8a5-e0bf6f327e64",
"c97b4a5d-95e1-48ac-b759-e31a047957b8",
"d07f938d-b9cd-4136-9c85-35a7b539b953",
"d5f1e7b3-cfd5-46ca-b911-b92f6055e43b",
"d94cc4ea-ddd8-4557-aa75-be9ff71a7636",
"dcab7183-d94a-43f3-a29b-3e6c861e0be4",
"e1ba9053-259a-4c20-90ae-a25156cf2de5",
"e30ea59c-446c-42d8-9880-d3bc0b8baffe",
"e43c9cdc-8fea-4e96-ae42-c2682b2a3fe4",
"eb60dafb-2977-4baf-93d1-ca343566fba9",
"ec2b254a-4964-4625-9999-2b08fe7efc73",
"f2a1dfd8-d27a-4414-a9f5-7531544ca6b4",
"f7d7bafa-dc85-43d8-8b1f-48f9c26958a8",
"fbdce111-c9af-4dde-9f36-62a775b816ae"
            };

            foreach (var id in ids)
            {
                var user = await _userManager.FindByIdAsync(id);
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, "Imuaythai24@");
            }

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("newadmin")]
        public async Task<IActionResult> CreateAdmin([FromQuery] string email, [FromQuery] string pass)
        {
            ApplicationUser user = new ApplicationUser
            {
                InstitutionId = 12,
                Email = email,
                FirstName = "User",
                Surname = "IMuayThai",
                UserName = email,
                CountryId = 177
            };
            
            await _userManager.CreateAsync(user);
            //await _userManager.AddToRoleAsync(user, "Admin");
            //await _userManager.AddToRoleAsync(user, "GymAdmin");
            await _userManager.AddToRoleAsync(user, "Fighter");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, "Imuaythai24@");

            return Ok(result);

        }
    }
}