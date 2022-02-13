using Ecommerce.Models.Database;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Index()
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                return View(db.Products.ToList());
            }

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Product());
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            product.Image = "../Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("../Image/"), fileName);
            product.ImageFile.SaveAs(fileName);
            using (EcommerceEntities db = new EcommerceEntities())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(Product p)
        {
            EcommerceEntities db = new EcommerceEntities();
            var data = (from product in db.Products
                where product.Id == p.Id
                select product).FirstOrDefault();

            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            using (EcommerceEntities db = new EcommerceEntities())
            {
                return View(db.Products.ToList());
            }
        }

    }
    
}