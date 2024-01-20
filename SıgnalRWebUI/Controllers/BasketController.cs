using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.BasketDTOs;
using System.Text;

namespace SıgnalRWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;//Program.cs de ekliyoruz.

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Listeleme İşlemi 
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturdum
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Baskets/BasketListByMenuTableWithProductName?id=4");//GetAsync HttpClient da var olan metot.Nereye Get isteğinde bulunacaksam orada var olan adresi alıyorum. 

            if (responseMessage.IsSuccessStatusCode) //Eğer  responseMessage başarılı durum koduna sahipse -->
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();//json dan gelen içeriği string formatında oku

                var values = JsonConvert.DeserializeObject<List<ResultBasketDto>>(jsondata);
                //burada jsondan gelen veriyi çözümleyip atacağım fakat bundan önce dto oluşturyorum.İlk yazdığımız dto lar sadece api ler için çalışıyordu şimdiki oluşturduğum dto lar ise jsondan gelen data propertyler den gelen datayı eşleştirecek.
                //JsonConvert NewtonSoftJson paketi ile kullanılıyor. 
                //Json datayı çözerken kullandığımız deserilaze yani json data normal bir metne dönüşüyor, jsona veri gönderiyorsam yani metni artık json data ya çevirmek için serilaze kullanıyorum. Listelerken deserilaze , eklerken güncellerken serilaze kullanılır.
                return View(values);
            }

            return View();
        }
        //Ürünü Silme İşlemi
        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Baskets/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
    }
}
