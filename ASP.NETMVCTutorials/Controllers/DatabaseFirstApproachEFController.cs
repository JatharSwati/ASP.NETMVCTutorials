using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class DatabaseFirstApproachEFController : Controller
    {
        DatabaseFirstEFDBEntities db = new DatabaseFirstEFDBEntities();
        // GET: DatabaseFirstApproachEF
        public ActionResult Index()
        {
            var data = db.Principals.ToList();
            return View(data);
        }

        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Principal p)
        {
            if(ModelState.IsValid == true)
            {
                db.Principals.Add(p);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Data Inserted !')</Script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Data Not Inserted !')</Script>";
                }
            }       

            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.Principals.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Principal p)
        {
           if(ModelState.IsValid == true)
            {
                db.Entry(p).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Updated !')</Script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Data Not Updated !')</Script>";
                }
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var deletedRow = db.Principals.Where(model => model.Id == id).FirstOrDefault();
                if(deletedRow != null)
                {
                    db.Entry(deletedRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted !')</Script>";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Deleted !')</Script>";
                    }
                }
            }
  
            return View();
        }

        //[HttpPost]
        //public ActionResult Delete(Principal p)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        db.Entry(p).State = EntityState.Deleted;
        //        int a = db.SaveChanges();
        //        if (a > 0)
        //        {
        //            TempData["DeleteMessage"] = "<script>alert('Data Deleted !')</Script>";
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            TempData["DeleteMessage"] = "<script>alert('Data Not Deleted !')</Script>";
        //        }
        //    }

        //    return View();
        //}

        public ActionResult Details(int id)
        {
            var row = db.Principals.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
    }
}