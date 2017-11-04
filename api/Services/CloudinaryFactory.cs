using CloudinaryDotNet;

namespace MuaythaiSportManagementSystemApi.Services
{
    class CloudinaryFactory
    {
        public Cloudinary GetDefaultCloudinaryObject()
        {
            Account account = new Account
            {
                ApiKey = "846494132354633",
                ApiSecret = "8NcTfg3hTDOq7fCHIqxyJMnq1dM",
                Cloud = "dfxixiniz"
            };

            return new Cloudinary(account);
        }
    }
}
