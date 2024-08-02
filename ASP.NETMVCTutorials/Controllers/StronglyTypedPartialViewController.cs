using ASP.NETMVCTutorials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NETMVCTutorials.Controllers
{
    public class StronglyTypedPartialViewController : Controller
    {
        // GET: StronglyTypedPartialView

        List<Product> ProductsList = new List<Product>()
        {
            new Product {Id = 1, Name = "Reebok Goggles", Price = 1000.00, Picture = "~/Images/Goggles.jpeg"},
            new Product {Id = 2, Name = "Reebok Shoes", Price = 10000.00, Picture = "~/Images/Shoes.jpeg"},            
            new Product {Id = 3, Name = "Reebok Watch", Price = 20000.00, Picture = "~/Images/Watch.jpeg"}
        };
        public ActionResult Index()
        {
            return View(ProductsList);
        }
    }
}