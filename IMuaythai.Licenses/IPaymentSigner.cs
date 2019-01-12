using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace IMuaythai.Licenses
{
    public interface IPaymentSigner
    {
        string SignPayment(int sessionId, int merchantId, int amount, string currency, string crc);
    }

    public class PaymentSigner : IPaymentSigner
    {
        public string SignPayment(int sessionId, int merchantId, int amount, string currency, string crc)
        {
            using (var md5 = MD5.Create())
            {
                var input = $"{sessionId}|{merchantId}|{amount}|{currency}|{crc}";
                var result = string.Join("", md5.ComputeHash(Encoding.ASCII.GetBytes(input)).Select(x => x.ToString("X2")));
                return result.ToLower();
            }
        }
    }
}