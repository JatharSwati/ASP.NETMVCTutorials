using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class ValidationMessageAndValidationSummaryMethodsController : Controller
    {
        string EmailPattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        // GET: ValidationMessageAndValidationSummaryMethods
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string FullName, string Age, string Email)
        {
            if(FullName.Equals("") == true)
            {
                ModelState.AddModelError("FullName", "FullName is required !");
                ViewData["FullNameError"] = "*";
            }

            if (Age.Equals("") == true)
            {
                ModelState.AddModelError("Age", "Age is required !");
                ViewData["AgeError"] = "*";
            }

            if (Email.Equals("") == true)
            {
                ModelState.AddModelError("Email", "Email is required !");
                ViewData["EmailError"] = "*";
            }
            else
            {
                if(Regex.IsMatch(Email, EmailPattern) == false)
                {
                    ModelState.AddModelError("Email", "Invalid Email !");
                    ViewData["EmailError"] = "*";
                }
            }

            if(ModelState.IsValid == true)
            {
                ViewData["SuccessMessage"] = "<script>alert('Data has been Submited !')</script>";
                ModelState.Clear();
            }


            return View();
        }
    }
}