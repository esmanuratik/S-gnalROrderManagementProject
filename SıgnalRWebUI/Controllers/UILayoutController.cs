using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
