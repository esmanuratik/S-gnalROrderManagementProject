using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
