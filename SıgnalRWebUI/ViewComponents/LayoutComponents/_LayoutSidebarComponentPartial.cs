using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutSidebarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
