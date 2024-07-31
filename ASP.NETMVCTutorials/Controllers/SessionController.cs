using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            ViewData["Var1"] = "Data comes from ViewData.";
            ViewBag.Var2 = "Data comes from ViewBag.";
            TempData["Var3"] = "Data comes from TempData.";
            Session["Var4"] = "Data comes from Session.";

            string[] students = { "Swati", "Pradip", "Shubhangi", "Pravin" };
            Session["StudentsArray"] = students;

            return View();
        }

        public ActionResult About()
        {
            if(Session["Var4"] != null)
            {
                Session["Var4"].ToString();
            }
            return View();
        }

        public ActionResult Contact()
        {
            if (Session["Var4"] != null)
            {
                Session["Var4"].ToString();
            }
            return View();
        }
    }
}