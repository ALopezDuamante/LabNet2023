﻿using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Practica7.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}