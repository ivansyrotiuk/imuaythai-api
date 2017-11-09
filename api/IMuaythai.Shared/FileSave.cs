using System;
using System.IO;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace IMuaythai.Shared
{
    public class FileSave : IFileSaver
    {
        public async Task<string> Save(string fileName, string base64String)
        {
            var cloudinary = GetCloudinaryUploader();
            var bytes = Convert.FromBase64String(base64String);
            var stream = new MemoryStream(bytes);
            var upload = new RawUploadParams
            {
                File = new FileDescription(fileName, stream)
            };
            var uploadResult = await cloudinary.UploadAsync(upload);


            return uploadResult.Uri.AbsoluteUri;
        }

        private Cloudinary GetCloudinaryUploader()
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