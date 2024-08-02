using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class StronglyTypeViewController : Controller
    {
        // GET: StronglyTypeView
        public ActionResult Index()
        {
            Student student1 = new Student();
            student1.StudentId = 01;
            student1.Name = "Swati Jathar";
            student1.Age = 23;

            Student student2 = new Student();
            student2.StudentId = 02;
            student2.Name = "Pradip Jathar";
            student2.Age = 25;

            Student student3 = new Student();
            student3.StudentId = 03;
            student3.Name = "Sakshi Jathar";
            student3.Age = 20;

            List<Student> StudentsLists = new List<Student>();
            StudentsLists.Add(student1);
            StudentsLists.Add(student2);
            StudentsLists.Add(student3);

            ViewData["Var1"] = student1;
            ViewBag.Var2 = student1;
            
            return View(StudentsLists);
        }
    }
}