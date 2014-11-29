﻿using System.Web.Mvc;

namespace Library.Web.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {


            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public virtual ActionResult About()
        {
            return View();
        }
    }
}
