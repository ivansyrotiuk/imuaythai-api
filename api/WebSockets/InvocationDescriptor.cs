using Newtonsoft.Json;

namespace MuaythaiSportManagementSystemApi.WebSockets
{
    public class InvocationDescriptor
    {
        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonPropertyAttribute("arguments")]
        public object[] Arguments { get; set; }
    }
}