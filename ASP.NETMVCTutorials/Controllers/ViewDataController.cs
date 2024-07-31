using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class ViewDataController : Controller
    {
        // GET: ViewData
        public ActionResult Index()
        {
            ViewData["Message"] = "Message from View Data !";
            ViewData["CurrentTime"] = DateTime.Now.ToLongTimeString();

            string[] Fruits = { "Apple", "Banana", "Grapes", "Orange" };
            ViewData["FruitsArray"] = Fruits;


            return View();
        }
    }
}