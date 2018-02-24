using Newtonsoft.Json;

namespace IMuaythai.Shared
{
    public static class JsonExtensions
    {
        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
