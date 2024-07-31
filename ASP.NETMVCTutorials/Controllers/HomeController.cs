using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string Show()
        {
            return "This is a second action method of HomeController.";
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public int StudentID(int id)
        {
            return id;
        }

    }
}