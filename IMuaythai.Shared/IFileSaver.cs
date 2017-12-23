namespace IMuaythai.Shared
{
    public interface IFileSaver
    {
        string Save(string fileName, string base64String);
    }
}