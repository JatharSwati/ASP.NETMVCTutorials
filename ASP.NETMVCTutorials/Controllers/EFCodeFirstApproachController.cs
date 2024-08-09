using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class EFCodeFirstApproachController : Controller
    {
        ManagerContext db = new ManagerContext();

        // GET: EFCodeFirstApproach
        public ActionResult Index()
        {
            var data = db.Managers.ToList();

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Manager m)
        {
            if(ModelState.IsValid == true)
            {
                db.Managers.Add(m);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data Inserted !')</script>";
                    //TempData["InsertMessage"] = "<script>alert('Data Inserted !')</script>";
                    TempData["InsertMessage"] = "Data Inserted !";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data not Inserted !')</script>";
                }
            }

            return View();
        }
    }
}