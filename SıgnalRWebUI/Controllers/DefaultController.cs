using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.MessageDtos;
using System.Text;

namespace SıgnalRWebUI.Controllers
{
    public class DefaultController : Controller
    {

		private readonly IHttpClientFactory _httpClientFactory;//Program.cs de ekliyoruz.

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Aynı sayfada mesajlaşma işleminin olması için ilk olarak partialview şeklinde daha sonra IActionResult şeklinde metot oluşturup metotların isimlerini aynı vereceğiz.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
		{
			var client = _httpClientFactory.CreateClient();//istemci oluşturdum
			var jsonData = JsonConvert.SerializeObject(createMessageDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürdüğüm veriyi encoding ile türkçe karakter almasını sağladığım yapı.

			var responseMessage = await client.PostAsync("https://localhost:7001/api/Messages", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
