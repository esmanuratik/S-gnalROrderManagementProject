using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.SocialMediaDTOs;
using System.Text;

namespace SıgnalRWebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;//Program.cs de ekliyoruz.

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        //Listeleme İşlemi 
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturdum
            var responseMessage = await client.GetAsync("https://localhost:7001/api/SocialMedia");//GetAsync HttpClient da var olan metot.Nereye Get isteğinde bulunacaksam orada var olan adresi alıyorum. 

            if (responseMessage.IsSuccessStatusCode) //Eğer  responseMessage başarılı durum koduna sahipse -->
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();//json dan gelen içeriği string formatında oku

                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsondata);
                //burada jsondan gelen veriyi çözümleyip atacağım fakat bundan önce dto oluşturyorum.İlk yazdığımız dto lar sadece api ler için çalışıyordu şimdiki oluşturduğum dto lar ise jsondan gelen data propertyler den gelen datayı eşleştirecek.
                //JsonConvert NewtonSoftJson paketi ile kullanılıyor. 
                //Json datayı çözerken kullandığımız deserilaze yani json data normal bir metne dönüşüyor, jsona veri gönderiyorsam yani metni artık json data ya çevirmek için serilaze kullanıyorum. Listelerken deserilaze , eklerken güncellerken serilaze kullanılır.
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturdum
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürdüğüm veriyi encoding ile türkçe karakter almasını sağladığım yapı.

            var responseMessage = await client.PostAsync("https://localhost:7001/api/SocialMedia", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/SocialMedia/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7001/api/SocialMedia/{id}");//İlk olarak güncellemem gereken id yi bulmalıyım.

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //json dan gelen içeriği string formatında oku
                var values = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);//güncelleyeceğim veriyi dto aracılığı ile dönmeliyim.Json veriyi metne dönüştürüyorum.
                return View(values);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürüp encoding ile türkçe karakter almasını sağladığım yapı.
            var responseMessage = await client.PutAsync("https://localhost:7001/api/SocialMedia", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
    }
}
