using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class LoginFormMVCController : Controller
    {
        LoginDBEntities db = new LoginDBEntities();

        // GET: LoginFormMVC
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User s)
        {
            if (ModelState.IsValid == true)
            {
                var credentials = db.Users.Where(model => model.UserName == s.UserName && model.Password == s.Password).FirstOrDefault();
                if (credentials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed !";
                    return View();
                }
                else
                {
                    Session["UserName"] = s.UserName;
                    return RedirectToAction("Index", "LoginFormHome");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginFormMVC");
        }

        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "LoginFormMVC");
        }

    }
}