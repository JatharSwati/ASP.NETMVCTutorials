using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class CookiesController : Controller
    {
        // GET: Cookies
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CookiesUser u)
        {
            if (ModelState.IsValid == true)
            {
                HttpCookie cookie = new HttpCookie("Username");
                cookie.Value = u.Username;

                HttpContext.Response.Cookies.Add(cookie);
                cookie.Expires = DateTime.Now.AddDays(2);
                return RedirectToAction("Index", "Dashboard");

            }
            return View();
        }
    }
}