using AuthorizeFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthorizeFilter.Controllers
{
    public class LoginController : Controller
    {

        LoginDatabaseEntities db = new LoginDatabaseEntities();

        // GET: Login

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(User u, string ReturnUrl)
        {
            if (IsValid(u) == true)
            {
                FormsAuthentication.SetAuthCookie(u.username, false);
                Session["Username"] = u.username.ToString();
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }            
        }

        public bool IsValid(User u)
        {
            var credentials = db.Users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
            if (credentials !=null)
            {
                return (u.username == credentials.username && u.password == credentials.password);
            }
            else
            {
                return false;
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Username"] = null;
            return RedirectToAction("Index", "Home");           
        }
    }
}