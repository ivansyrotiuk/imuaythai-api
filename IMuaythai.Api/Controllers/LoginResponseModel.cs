using IMuaythai.Models.AccountModels;

namespace IMuaythai.Api.Controllers
{

        public class LoginResponseModel
        {
            public string AuthToken { get; set; }
            public bool RememberMe { get; set; }
            public string QrCode { get; set; }
            public AutorizedUserResponseModel User { get; set; }
        }
    
}