﻿using System.Web.Mvc;

namespace MvcApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}