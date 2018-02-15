namespace IMuaythai.Shared
{
    public class Base64StringExtractor : IBase64StringExtractor
    {
        public string ExtractBase64String(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            var base64Array = input.Split(',');
            return base64Array.Length > 1 ? base64Array[1] : null;
        }
    }
}