using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
