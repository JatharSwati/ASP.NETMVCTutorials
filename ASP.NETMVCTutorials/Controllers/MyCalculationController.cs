using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class MyCalculationController : Controller
    {
        // GET: MyCalculation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Calculation C)
        {
            int Num1 = C.Num1;
            int Num2 = C.Num2;
            int Result = Num1 + Num2;

            ViewBag.Result = Result;

            return View();
        }
    }
}