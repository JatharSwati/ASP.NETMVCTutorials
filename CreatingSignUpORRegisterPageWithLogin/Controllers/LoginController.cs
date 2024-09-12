using CreatingSignUpORRegisterPageWithLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreatingSignUpORRegisterPageWithLogin.Controllers
{
    public class LoginController : Controller
    {
        SignupLoginEntities db = new SignupLoginEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            var user = db.Users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
            if (User != null)
            {
                Session["UserId"] = u.id.ToString();
                Session["Username"] = u.username.ToString();
                TempData["LoginSuccessfulMessage"] = "<script>alert('Login Successful !')</script>";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or password is incorrect !')</script>";
            }

            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User u)
        {
            if (ModelState.IsValid == true)
            {
                db.Users.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully !')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registeration Failed !')</script>";
                }
            }

            return View();
        }
    }
}