using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted !')</script>";
                }
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Managers.Where(model => model.Id == id).FirstOrDefault();

            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Manager m)
        {
            if(ModelState.IsValid == true)
            {
                db.Entry(m).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.UpdateMessage = "<script>alert('Data Updated !')</script>";
                    //TempData["UpdateMessage"] = "<script>alert('Data Updated !')</script>";
                    TempData["UpdateMessage"] = "Data Updated !";
                    return RedirectToAction("Index");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Updated !')</script>";
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            if(id > 0)
            {
                var ManagerIdRow = db.Managers.Where(model => model.Id == id).FirstOrDefault();
                if(ManagerIdRow != null)
                {
                    db.Entry(ManagerIdRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if(a > 0)
                    {
                        //TempData["DeleteMessage"] = "<script>alert('Data Deleted !')</script>";
                        TempData["DeleteMessage"] = "Data Deleted !";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Deleted !')</script>";
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var DetailsById = db.Managers.Where(model => model.Id == id).FirstOrDefault();

            return View(DetailsById);
        }

    }
}