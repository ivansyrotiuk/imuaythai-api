using Newtonsoft.Json;

namespace IMuaythai.JudgingServer
{
    public class InvocationDescriptor
    {
        [JsonProperty("methodName")]
        public string MethodName { get; set; }

        [JsonProperty("arguments")]
        public object[] Arguments { get; set; }
    }
}