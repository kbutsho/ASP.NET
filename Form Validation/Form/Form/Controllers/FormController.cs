using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Form.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        [HttpGet]
        public ActionResult Registration()
        {
            return View(new Models.Form());
        }
        [HttpPost]
        public ActionResult Registration(Models.Form data)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Dashboard", data);
            }
            else
            {
                return View(data);
            }
        }
        public ActionResult Dashboard(Models.Form data)
        {
            return View(data);
        }

    }
}