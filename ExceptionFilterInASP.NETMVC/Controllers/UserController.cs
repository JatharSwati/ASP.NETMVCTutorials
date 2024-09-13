using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionFilterInASP.NETMVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User

        [HandleError(View = "Error2")]
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        }
    }
}