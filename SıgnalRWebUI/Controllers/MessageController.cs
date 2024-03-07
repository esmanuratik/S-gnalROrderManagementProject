using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
