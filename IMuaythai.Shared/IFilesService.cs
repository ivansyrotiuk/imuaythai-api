using System;
using System.Collections.Generic;
using System.Text;

namespace IMuaythai.Shared
{
    public interface IFilesService
    {
        string UploadFile(string fileBase64String);
        string UploadFile(string fileName, string fileBase64String);
    }
}
