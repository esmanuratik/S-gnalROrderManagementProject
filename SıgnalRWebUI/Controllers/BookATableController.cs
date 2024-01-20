using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.BookingDTOs;
using System.Net.Http;
using System.Text;

namespace SıgnalRWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;//Program.cs de ekliyoruz.

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //Rezervasyon Oluşturma İşlemi
        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createbookingDto)
        {
			createbookingDto.Description = "Rezervasyon Alındı";
			var client = _httpClientFactory.CreateClient();//istemci oluşturdum
            var jsonData = JsonConvert.SerializeObject(createbookingDto);
			
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürdüğüm veriyi encoding ile türkçe karakter almasını sağladığım yapı.

            var responseMessage = await client.PostAsync("https://localhost:7001/api/Bookings", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
