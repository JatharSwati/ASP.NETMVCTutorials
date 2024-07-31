using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class DifferenceViewDataViewBagController : Controller
    {
        // GET: DifferenceViewDataViewBag
        public ActionResult Index()
        {
            ViewData["Message1"] = "Data comes from ViewData";
            ViewBag.Message1 = "Data comes from ViewBag";


            ViewData["CurrentDate1"] = DateTime.Now.ToString();
            ViewBag.CurrentDate2 = DateTime.Now.ToString();


            string[] Games = { "Cricket", "Football", "Hockey", "Baseball" };
            ViewData["GamesArray1"] = Games;
            ViewBag.GamesArray2 = Games;


            Teacher Pradip = new Teacher();
            Pradip.TeacherId = 5;
            Pradip.Age = 24;
            Pradip.Name = "Pradip Jathar";
            Pradip.Salary = 63000;

            ViewData["Teacher1"] = Pradip;
            ViewBag.Teacher2 = Pradip;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}