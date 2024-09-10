using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadingAndRetrievingImagesFromDatabase.Models;

namespace UploadingAndRetrievingImagesFromDatabase.Controllers
{
    public class HomeController : Controller
    {

        StudentDBEntities db = new StudentDBEntities();

        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student s)
        {
            string fileName = Path.GetFileNameWithoutExtension(s.ImageFile.FileName);
            string extension = Path.GetExtension(s.ImageFile.FileName);

            HttpPostedFileBase postedFile = s.ImageFile;
            int length = postedFile.ContentLength;

            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".png" || extension.ToLower() == ".jpeg")
            {
                if (length <= 1000000)
                {
                    fileName = fileName + extension;
                    s.imagePath = "~/Images/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    s.ImageFile.SaveAs(fileName);
                    db.Students.Add(s);
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        ViewBag.Message = "<script>alert('Record Inserted !')</script>";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = "<script>alert('Record Not Inserted !')</script>";
                    }
                }
                else
                {
                    ViewBag.SizeMessage = "<script>alert('Size should be of 1 MB !')</script>";
                }
            }
            else
            {
                ViewBag.ExtensionMessage = "<script>alert('Image Not Supported !')</script>";
            }

            return View();
        }
    }
}