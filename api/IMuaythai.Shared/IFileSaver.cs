using System.Threading.Tasks;

namespace IMuaythai.Shared
{
    public interface IFileSaver
    {
        Task<string> Save(string fileName, string base64String);
    }
}