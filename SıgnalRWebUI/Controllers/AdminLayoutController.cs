﻿using Microsoft.AspNetCore.Mvc;

namespace SıgnalRWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
