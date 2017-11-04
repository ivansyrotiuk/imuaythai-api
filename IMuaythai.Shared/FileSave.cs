using System;

namespace IMuaythai.Shared
{
    public class FileSave : IFileSaver
    {
        public string Save(string hostUrl, string base64String)
        {
            var bytes = Convert.FromBase64String(base64String);

            var imageName = $"images/{Guid.NewGuid().ToString().Substring(0, 10)}.png";
            System.IO.File.WriteAllBytes($"./wwwroot/{imageName}", bytes);
            var location = new Uri(hostUrl);

            return location.AbsoluteUri + imageName;
        }
    }
}