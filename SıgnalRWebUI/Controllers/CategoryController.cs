using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
