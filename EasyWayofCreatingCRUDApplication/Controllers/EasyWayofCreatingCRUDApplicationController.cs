using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyWayofCreatingCRUDApplication.Models;

namespace EasyWayofCreatingCRUDApplication.Controllers
{
    public class EasyWayofCreatingCRUDApplicationController : Controller
    {
        private ManagerDBEntities db = new ManagerDBEntities();

        // GET: EasyWayofCreatingCRUDApplication
        public ActionResult Index()
        {
            return View(db.mangs.ToList());
        }

        // GET: EasyWayofCreatingCRUDApplication/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mang mang = db.mangs.Find(id);
            if (mang == null)
            {
                return HttpNotFound();
            }
            return View(mang);
        }

        // GET: EasyWayofCreatingCRUDApplication/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EasyWayofCreatingCRUDApplication/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,age,designation")] mang mang)
        {
            if (ModelState.IsValid)
            {
                db.mangs.Add(mang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mang);
        }

        // GET: EasyWayofCreatingCRUDApplication/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mang mang = db.mangs.Find(id);
            if (mang == null)
            {
                return HttpNotFound();
            }
            return View(mang);
        }

        // POST: EasyWayofCreatingCRUDApplication/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,age,designation")] mang mang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mang);
        }

        // GET: EasyWayofCreatingCRUDApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mang mang = db.mangs.Find(id);
            if (mang == null)
            {
                return HttpNotFound();
            }
            return View(mang);
        }

        // POST: EasyWayofCreatingCRUDApplication/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mang mang = db.mangs.Find(id);
            db.mangs.Remove(mang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
