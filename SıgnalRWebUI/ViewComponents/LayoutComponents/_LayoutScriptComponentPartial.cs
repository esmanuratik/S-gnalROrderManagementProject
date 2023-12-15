using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.ViewComponents.LayoutComponents
{
	public class _LayoutScriptComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
