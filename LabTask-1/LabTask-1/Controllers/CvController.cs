using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask_1.Controllers
{
    public class CvController : Controller
    {
        // GET: Cv
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult Reference()
        {
            return View();
        }
    }
}