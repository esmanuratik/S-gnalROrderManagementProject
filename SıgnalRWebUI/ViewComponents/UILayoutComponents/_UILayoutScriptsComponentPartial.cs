using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
