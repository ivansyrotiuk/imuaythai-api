using System;
using IMuaythai.HttpServices;
using IMuaythai.Shared;

namespace IMuaythai.CloudinaryFiles
{
    public class CloudinaryFilesService : IFilesService
    {
        private readonly IFileSaver _fileSaver;
        private readonly IBase64StringExtractor _base64StringExtractor;
        private readonly IHttpUserContext _httpUserContext;

        public CloudinaryFilesService(IFileSaver fileSaver, IBase64StringExtractor base64StringExtractor, IHttpUserContext httpUserContext)
        {
            _fileSaver = fileSaver;
            _base64StringExtractor = base64StringExtractor;
            _httpUserContext = httpUserContext;
        }

        public string UploadFile(string fileBase64String)
        {
            var request = _httpUserContext.GetHttpContext()?.Request;
            var fileName = $"{request?.Scheme}://{request?.Host}/{Guid.NewGuid()}";
            return UploadFile(fileName, fileBase64String);
        }

        public string UploadFile(string fileName, string fileBase64String)
        {
            var base64String = _base64StringExtractor.ExtractBase64String(fileBase64String);
            return string.IsNullOrEmpty(base64String) ? null : _fileSaver.Save(fileName, base64String);
        }
    }
}