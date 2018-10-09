using System.Threading.Tasks;
using IMuaythai.DataAccess.Models;
using IMuaythai.Models.AccountModels;
using IMuaythai.Models.Users;

namespace IMuaythai.Auth
{
    public interface IAuthService
    {
        Task<LoginResponseModel> Login(LoginDto model);
        Task Register(RegistrationModel model);
        Task<string> FinishRegistration(FinishRegistrationModel model);
        Task Logout();
        Task<ApplicationUser> CreateUser(CreateUserModel createUserModel);
        Task ConfirmEmail(string userId, string code);
        Task ForgotPassword(ForgotPasswordDto model);
        Task ResetPassword(ResetPasswordDto model);
    }
}