using System.Collections.Generic;
using System.Threading.Tasks;
using RestEase;

namespace IMuaythai.Licenses
{
    public interface IPayments24Client
    {
        [Post("trnVerify")]
        Task<Response<object>> Pay([Body(BodySerializationMethod.UrlEncoded)]Dictionary<string, object> body);
    }
}