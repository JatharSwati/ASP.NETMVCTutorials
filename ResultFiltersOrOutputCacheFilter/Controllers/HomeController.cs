using ResultFiltersOrOutputCacheFilter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResultFiltersOrOutputCacheFilter.Controllers
{
    public class HomeController : Controller    {

        PersonDBEntities db = new PersonDBEntities();

        // GET: Home

        [OutputCache(Duration = 20, Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            ViewBag.Time = DateTime.Now.ToLongTimeString();
            return View();
        }

        [OutputCache(Duration = 60)]
        public ActionResult GetData()
        {
            var data = db.People.ToList();
            return View(data);
        }
    }
}