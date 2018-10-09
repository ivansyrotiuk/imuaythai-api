using System;
using System.Linq;
using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Exceptions;
using IMuaythai.HttpServices;
using IMuaythai.Models.AccountModels;
using IMuaythai.Models.Users;
using IMuaythai.Repositories;
using IMuaythai.Services;
using IMuaythai.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace IMuaythai.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IInstitutionsRepository _institutionsRepository;
        private readonly IUserRoleRequestsRepository _userRoleRequestsRepository;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly IJwtTokenGenerator _tokenGenerator;
        private readonly IUsersService _usersService;
        private readonly IHttpUserContext _userContext;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IInstitutionsRepository institutionsRepository, IUserRoleRequestsRepository userRoleRequestsRepository,
            IEmailSender emailSender, ILoggerFactory loggerFactory, IJwtTokenGenerator tokenGenerator, IUsersService usersService, IHttpUserContext userContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _institutionsRepository = institutionsRepository;
            _userRoleRequestsRepository = userRoleRequestsRepository;
            _emailSender = emailSender;
            _logger = loggerFactory.CreateLogger<AuthService>();
            _tokenGenerator = tokenGenerator;
            _usersService = usersService;
            _userContext = userContext;
        }

        public async Task<LoginResponseModel> Login(LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
                throw new AuthException(result.IsLockedOut ? "User account locked out." : "Invalid login or password");

            var user = await _userManager.FindByEmailAsync(model.Email) ??
                       await _userManager.FindByNameAsync(model.Email);

            var roles = await _userManager.GetRolesAsync(user);

            var encodedToken = _tokenGenerator.GenerateToken(user, roles);
            return new LoginResponseModel
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
            };
        }

        public async Task Register(RegistrationModel model)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new AuthException($"Something went wrong: {string.Join(", ", result.Errors.Select(e => e.Description))}");

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackLink = MakeCallbackLink(model.CallbackUrl, user, code, "activation link");

            await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                $"Please confirm your account go to this link: {callbackLink}");

            _logger.LogInformation("User created a new account with password.");
        }

        public async Task<string> FinishRegistration(FinishRegistrationModel model)
        {
            var user = await _userManager.FindByIdAsync(_userContext.GetUserId());
            if (user == null)
                throw new NotFoundException("User not found");

            var gym = model.OwnGym == true
                ? await SaveNewGym(model.GymName, model.CountryId)
                : await _institutionsRepository.Get(model.InstitutionId ?? 0);

            var entity = new UserRoleRequest
            {
                RoleId = model.RoleId,
                UserId = _userContext.GetUserId(),
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
            return _tokenGenerator.GenerateToken(user, roles);
        }

        private async Task<Institution> SaveNewGym(string gymName, int countryId)
        {
            var gym = new Institution
            {
                Name = gymName,
                CountryId = countryId
            };
            await _institutionsRepository.Save(gym);
            return gym;
        }

        public Task Logout()
        {
            _logger.LogInformation("User logged out.");
            return _signInManager.SignOutAsync();
        }

        public async Task<ApplicationUser> CreateUser(CreateUserModel createUserModel)
        {
            var user = await _usersService.CreateUser(createUserModel);
            var request = _userContext.GetHttpContext().Request;
            await _emailSender.SendEmailAsync(createUserModel.Email, "Imuaythai",
                $"Your IMuaythai account is ready. Go to <a href=\"{request.Scheme}://{request.Host.ToUriComponent()}\">IMuaythai</a>");
            return user;
        }

        public async Task ConfirmEmail(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId) ??
                       throw new NotFoundException("User not found");

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (!result.Succeeded)
                throw new AuthException($"Something went wrong: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        public async Task ForgotPassword(ForgotPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email) ??
                       throw new NotFoundException("User not found");

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                throw new AuthException("Email is not confirmed");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackLink = MakeCallbackLink(model.CallbackUrl, user, code, "link");

            await _emailSender.SendEmailAsync(model.Email, "Reset password",
                $"Please reset your password by clicking this link: {callbackLink}");
        }

        public async Task ResetPassword(ResetPasswordDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId) ??
                       throw new NotFoundException("User not found");

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (!result.Succeeded)
            {
                throw new AuthException($"Password not resetted: {string.Join(",", result.Errors.Select(e => e.Description))}");
            }
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

    }
}