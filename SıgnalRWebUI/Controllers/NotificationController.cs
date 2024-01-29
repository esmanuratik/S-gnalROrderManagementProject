using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.NotificationDTOs;
using System.Text;

namespace SıgnalRWebUI.Controllers
{
	public class NotificationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;//Program.cs de ekliyoruz.

		public NotificationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		//Listeleme İşlemi 
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();//istemci oluşturdum
			var responseMessage = await client.GetAsync("https://localhost:7001/api/Notifications");//GetAsync HttpClient da var olan metot.Nereye Get isteğinde bulunacaksam orada var olan adresi alıyorum. 

			if (responseMessage.IsSuccessStatusCode) //Eğer  responseMessage başarılı durum koduna sahipse -->
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();//json dan gelen içeriği string formatında oku

				var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsondata);
				//burada jsondan gelen veriyi çözümleyip atacağım fakat bundan önce dto oluşturyorum.İlk yazdığımız dto lar sadece api ler için çalışıyordu şimdiki oluşturduğum dto lar ise jsondan gelen data propertyler den gelen datayı eşleştirecek.
				//JsonConvert NewtonSoftJson paketi ile kullanılıyor. 
				//Json datayı çözerken kullandığımız deserilaze yani json data normal bir metne dönüşüyor, jsona veri gönderiyorsam yani metni artık json data ya çevirmek için serilaze kullanıyorum. Listelerken deserilaze , eklerken güncellerken serilaze kullanılır.
				return View(values);
			}

			return View();
		}
		[HttpGet]
		public IActionResult CreateNotification()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
		{
			var client = _httpClientFactory.CreateClient();//istemci oluşturdum
			var jsonData = JsonConvert.SerializeObject(createNotificationDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürdüğüm veriyi encoding ile türkçe karakter almasını sağladığım yapı.

			var responseMessage = await client.PostAsync("https://localhost:7001/api/Notifications", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7001/api/Notifications/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}
		public async Task<IActionResult> UpdateNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7001/api/Notifications/{id}");//İlk olarak güncellemem gereken id yi bulmalıyım.

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync(); //json dan gelen içeriği string formatında oku
				var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);//güncelleyeceğim veriyi dto aracılığı ile dönmeliyim.Json veriyi metne dönüştürüyorum.
				return View(values);
			}
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürüp encoding ile türkçe karakter almasını sağladığım yapı.
			var responseMessage = await client.PutAsync("https://localhost:7001/api/Notifications", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

		}
        public async Task<IActionResult> NotificationChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7001/api/Notifications/NotificationChangeToTrue/{id}");//İlk olarak güncellemem gereken id yi bulmalıyım.
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> NotificationChangeToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"https://localhost:7001/api/Notifications/NotificationChangeToFalse/{id}");//İlk olarak güncellemem gereken id yi bulmalıyım.
            return RedirectToAction("Index");
        }
    }
}
