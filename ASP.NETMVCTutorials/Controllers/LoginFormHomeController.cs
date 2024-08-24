using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class LoginFormHomeController : Controller
    {
        // GET: LoginFormHome
        public ActionResult Index()
        {
            if (@Session["UserName"] == null)
            {
                return RedirectToAction("Index", "LoginFormMVC");
            }

            return View();
        }
    }
}