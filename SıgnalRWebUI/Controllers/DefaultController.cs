using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
