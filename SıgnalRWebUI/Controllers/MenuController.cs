using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SıgnalRWebUI.DTOs.BasketDTOs;
using SıgnalRWebUI.DTOs.ProductDTOs;
using System.Text;

namespace SıgnalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Products");
            var  jsonData=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)//Sepete tıkladığım id ye gittiği için burada sadece id gönderiyorum
        {
            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductID = id;//Arka tarafta ProductID ye atayıp API tarafında bunun detyalarını almak 
            var client = _httpClientFactory.CreateClient();//istemci oluşturdum
            var jsonData = JsonConvert.SerializeObject(createBasketDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//jsona dönüştürdüğüm veriyi encoding ile türkçe karakter almasını sağladığım yapı.

            var responseMessage = await client.PostAsync("https://localhost:7001/api/Baskets", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);//Json olarak bu nesneyi döndürmüş oldum böylece aynı sayfa alert den sonra geri dönmüş olacak.
        }
    }
}
