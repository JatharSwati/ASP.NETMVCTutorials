using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class DataAnnotationController : Controller
    {
        // GET: DataAnnotation
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            if(ModelState.IsValid == true)
            {
                ViewData["SuccessMessage"] = "<script>alert('Data has been Submited !')</script>";
                ModelState.Clear();
            }
            return View();
        }
        
    }
}