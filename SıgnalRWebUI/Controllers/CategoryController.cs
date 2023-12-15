using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
        {
            var client=_httpClientFactory.CreateClient();//istemci oluşturdum
            return View();
        }
    }
}
