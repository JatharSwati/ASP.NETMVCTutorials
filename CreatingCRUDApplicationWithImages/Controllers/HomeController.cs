using CreatingCRUDApplicationWithImages.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreatingCRUDApplicationWithImages.Controllers
{
    public class HomeController : Controller
    {

        EmpDBEntities db = new EmpDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            var data = db.EmpTables.ToList();
            return View(data);
        }

        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpTable e)
        {
            if (ModelState.IsValid == true)
            {
                string fileName = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                string extension = Path.GetExtension(e.ImageFile.FileName);
                HttpPostedFileBase postedFile = e.ImageFile;
                int length = postedFile.ContentLength;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extension;
                        e.imagePath = "~/Images/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                        e.ImageFile.SaveAs(fileName);
                        db.EmpTables.Add(e);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Inserted Successfully !')</script>";
                            ModelState.Clear();
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Not Inserted !')</script>";
                        }
                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Image size should be less than 1 MB.')</script>";
                    }
                }
                else
                {
                    TempData["ExtensionMessage"] = "<script>alert('Format Not Supported !')</script>";
                }
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var EmployeeRow = db.EmpTables.Where(model => model.id == id).FirstOrDefault();
            Session["Image"] = EmployeeRow.imagePath;
            return View(EmployeeRow);
        }

        [HttpPost]
        public ActionResult Edit(EmpTable e)
        {
            if (ModelState.IsValid == true)
            {
                if (e.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                    string extension = Path.GetExtension(e.ImageFile.FileName);
                    HttpPostedFileBase postedFile = e.ImageFile;
                    int length = postedFile.ContentLength;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extension;
                            e.imagePath = "~/Images/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                            e.ImageFile.SaveAs(fileName);
                            db.Entry(e).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                TempData["DeleteMessage"] = "<script>alert('Data Deleted Successfully !')</script>";
                                string ImagePath = Request.MapPath(Session["Image"].ToString());
                                if (System.IO.File.Exists(ImagePath))
                                {
                                    System.IO.File.Delete(ImagePath);
                                }

                                TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully !')</script>";
                                ModelState.Clear();
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                TempData["UpdateMessage"] = "<script>alert('Data Not Updated !')</script>";
                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image size should be less than 1 MB.')</script>";
                        }
                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported !')</script>";
                    }
                }
                else
                {
                    e.imagePath = Session["Image"].ToString();
                    db.Entry(e).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Updated Successfully !')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["UpdateMessage"] = "<script>alert('Data Not Updated !')</script>";
                    }
                }

            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var EmployeeRow = db.EmpTables.Where(model => model.id == id).FirstOrDefault();

                if (EmployeeRow != null)
                {
                    db.Entry(EmployeeRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted Successfully !')</script>";
                        string ImagePath = Request.MapPath(EmployeeRow.imagePath.ToString());
                        if (System.IO.File.Exists(ImagePath))
                        {
                            System.IO.File.Delete(ImagePath);
                        }
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Deleted !')</script>";
                    }
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var EmployeeRow = db.EmpTables.Where(model => model.id == id).FirstOrDefault();
            Session["Image2"] = EmployeeRow.imagePath.ToString();
            return View(EmployeeRow);
        }
    }
}