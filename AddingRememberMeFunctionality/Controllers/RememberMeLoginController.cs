using AddingRememberMeFunctionality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AddingRememberMeFunctionality.Controllers
{
    public class RememberMeLoginController : Controller
    {
        RememberMeLoginDBEntities db = new RememberMeLoginDBEntities();

        // GET: RememberMeLogin
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["RememberMeUser"];
            if (cookie != null)
            {
                ViewBag.Username = cookie["Username"].ToString();

                string EncryptePassword = cookie["Passwaord"].ToString();
                byte[] b = Convert.FromBase64String(EncryptePassword);
                string decryptPassword = ASCIIEncoding.ASCII.GetString(b);
                ViewBag.Password = decryptPassword.ToString();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(RememberMeUser u)
        {
            HttpCookie cookie = new HttpCookie("RememberMeUser");

            if (ModelState.IsValid == true)
            {
                if (u.RememberMe == true)
                {
                    cookie["Username"] = u.Username;

                    byte[] b = ASCIIEncoding.ASCII.GetBytes(u.Password);
                    string EncryptedPassword = Convert.ToBase64String(b);
                    cookie["Passwaord"] = EncryptedPassword;
                    cookie.Expires = DateTime.Now.AddDays(2);
                    HttpContext.Response.Cookies.Add(cookie);
                }
                else
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    HttpContext.Response.Cookies.Add(cookie);
                }

                var row = db.RememberMeUsers.Where(model => model.Username == u.Username && model.Password == u.Password).FirstOrDefault();
                if (row != null)
                {
                    Session["Username"] = u.Username;
                    TempData["Message"] = "<script>alert('Login Successfully !')</script>";
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    TempData["Message"] = "<script>alert('Login Failed !')</script>";
                }
            }
            return View();
        }
    }
}