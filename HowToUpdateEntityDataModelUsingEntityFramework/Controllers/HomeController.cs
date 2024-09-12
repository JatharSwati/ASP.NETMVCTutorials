using HowToUpdateEntityDataModelUsingEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HowToUpdateEntityDataModelUsingEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        EDMExampleMVCEntities db = new EDMExampleMVCEntities();

        // GET: Home
        public ActionResult Student()
        {
            var data = db.StudentTables.ToList();
            return View(data);
        }

        public ActionResult Employee()
        {
            var data = db.EmployeeTables.ToList();
            return View(data);
        }
    }
}