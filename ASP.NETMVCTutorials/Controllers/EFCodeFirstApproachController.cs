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
    }
}