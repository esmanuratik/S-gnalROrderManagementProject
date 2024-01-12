using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookTableComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
