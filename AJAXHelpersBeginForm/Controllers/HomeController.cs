using AJAXHelpersBeginForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAXHelpersBeginForm.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDatabaseEntities db = new EmployeeDatabaseEntities();

        // GET: Home
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Employees.Add(e);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    return JavaScript("alert('Data Inserted !')");
                }
                else
                {
                    return JavaScript("alert('Data Not Inserted !')");
                }
            }
            return View();
        }

    }
}