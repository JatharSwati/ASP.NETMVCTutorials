using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AddingRememberMeFunctionality.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Index", "RememberMeLogin");
            }
            else
            {
                return View();
            }            
        }

        public ActionResult Logout()
        {
            if (Session["Username"] != null)
            {                
                Session.Abandon();
                return RedirectToAction("Index", "RememberMeLogin");
            }

            return View();
        }
    }
}