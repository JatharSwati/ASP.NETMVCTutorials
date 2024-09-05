﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["Username"];

            if (cookie != null)
            {
                ViewBag.Message = Request.Cookies["Username"].Value.ToString();
            }
            else
            {
                return RedirectToAction("Index", "Cookies");
            }

            return View();
        }
    }
}