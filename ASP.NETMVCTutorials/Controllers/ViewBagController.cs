using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class ViewBagController : Controller
    {
        // GET: ViewBag
        public ActionResult Index()
        {

            ViewBag.Message = "Message from View Bag!";
            ViewBag.CurrentDate = DateTime.Now.ToLongDateString();

            string[] Fruits = { "Apple", "Banana", "Grapes", "Orange" };
            ViewBag.FruitsArray = Fruits;

            ViewBag.SportsList = new List<string>()
            {
                "Cricket",
                "Football",
                "Hockey",
                "Baseball"
            };

            Employee Anas = new Employee();
            Anas.EmployeeId = 30;
            Anas.Name = "Swati Jatahr";
            Anas.Designation = "Manager";

            ViewBag.Employee = Anas;

            ViewBag.CommonMessage = "This message is accessible by both ViewBag or ViewData";

            return View();
        }
    }
}