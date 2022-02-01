using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabTask_2.Models;

namespace LabTask_2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Products()
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                var p = new Product();
                p.Id = i + 1;
                p.ProductName = "Product" + (i + 1);
                products.Add(p);

            }
            return View(products);
        }
    }
}