using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SıgnalRWebUI.Controllers
{
    public class QrCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            //base64 formatında rl de şifrelenmiş QR Code formatı oluşturma 
            using (MemoryStream memoryStream = new MemoryStream())
            {
                QRCodeGenerator createQRCode=new QRCodeGenerator(); //QrCodeGenerator QrCoder Dll ile birlikte gelen bir sınıf.

                //Qr Code içeriğini oluşturuyor.
                QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q); 

                //Bitmap System.Drawing kütüphanesinden gelir ve çizimler için kullanılır. Bellekte oluşturulan QrCode un çizimini oluşturur.
                using (Bitmap image = squareCode.GetGraphic(10)) //GetGraphic pixel değerini oluşturur.
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    ViewBag.QrCodeImage="data:image/png;base64,"+Convert.ToBase64String(memoryStream.ToArray());
                    //Viewbag yardımıyla herhangi bir yere taşımış olacağım.QrCode görselini olultrumak kullandığımız ifade "data:image/png;base64,"
                }
            };
            return View();
        }
    }
}
