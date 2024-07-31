using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class TempDataController : Controller
    {
        // GET: TempData
        public ActionResult Index()
        {
            ViewData["Var1"] = "Message from ViewData";
            ViewBag.Var2 = "Message from ViewBag";
            TempData["Var3"] = "Message from Temdata";

            //string[] games = { "Cricket", "Football", "Hockey", "Basketball" };
            //TempData["GamesArray"] = games;

            return RedirectToAction("About");
            //return View();
        }

        public ActionResult About()
        {
            if(TempData["Var3"] != null)
            {
                TempData["Var3"].ToString();
            }
            TempData.Keep();
            return View();
        }

        public ActionResult Contact()
        {
            if (TempData["Var3"] != null)
            {
                TempData["Var3"].ToString();
            }
            return View();
        }
    }
}