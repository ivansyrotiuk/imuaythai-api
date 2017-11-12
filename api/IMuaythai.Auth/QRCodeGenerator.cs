using System;
using System.IO;
using ImageSharp;
using Newtonsoft.Json;
using ZXing.QrCode;

namespace IMuaythai.Auth
{
    public static class QRCodeGenerator
    {
        public static string GenerateQRCode(object data){
            var width = 250; // width of the Qr Code 
            var height = 250; // height of the Qr Code 
            var margin = 0; 
 
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData 
            { 
                Format = ZXing.BarcodeFormat.QR_CODE, 
                Options = new QrCodeEncodingOptions { Height = height, Width = width, Margin = margin } 
            }; 

            var jsonData = JsonConvert.SerializeObject(data);
            var pixelData = qrCodeWriter.Write(jsonData);
            using (var ms = new MemoryStream()) 
            {
                var qrCodeImg = Image.LoadPixelData<Rgba32>(new Span<byte>(pixelData.Pixels), pixelData.Width, pixelData.Height);
                qrCodeImg.SaveAsPng(ms);
                return String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray()));
            }           
        }
    }
}