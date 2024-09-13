using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionFilterInASP.NETMVC.Controllers
{
    [HandleError(View = "Error")]
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            //1] DivideByZeroException
            //int a = 10;
            //int b = 0;
            //int c = a / b;

            //2] NullReferenceException
            //string a = null;
            //int b = a.Length;

            //3] IndexOutOfRangeException
            //int[] a = new int[3];
            //a[0] = 11;
            //a[1] = 22;
            //a[2] = 33;
            //a[3] = 44;

            //4] Exception
            //throw new Exception();

            // Using try catch Exception Handling.
            //try
            //{
            //    throw new Exception();
            //}
            //catch (Exception ex)
            //{

            //    return RedirectToAction("ErrorMessage", "Home");
            //}


            throw new Exception();
            return View();
        }

        public ActionResult About()
        {
            throw new Exception();
            return View();
        }

        //public ActionResult ErrorPage()
        //{
        //    return View();
        //}
    }
}