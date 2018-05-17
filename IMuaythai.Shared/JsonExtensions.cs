using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace IMuaythai.Shared
{
    public static class JsonExtensions
    {
        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Serialize(this object obj)
        {
            return JsonConvert.SerializeObject(obj,  new JsonSerializerSettings 
            { 
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
