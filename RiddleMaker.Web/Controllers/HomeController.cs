﻿using Microsoft.AspNetCore.Mvc;

namespace RiddleMaker.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}