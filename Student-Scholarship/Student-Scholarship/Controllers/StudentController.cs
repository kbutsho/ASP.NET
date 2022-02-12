using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_Scholarship.Models.Database;


namespace Student_Scholarship.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            LabTask4Entities2 db = new LabTask4Entities2();

         var data = db.Students.ToList();

        return View(data);




        }
        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View(new Student());
        }

        [HttpPost]
        
        public ActionResult CreateStudent(Student s)
        {
           if(ModelState.IsValid){

               LabTask4Entities2 db = new LabTask4Entities2();
               db.Students.Add(s);
               db.SaveChanges();
               return RedirectToAction("index");
           }

           return View();
        }

        public ActionResult SpecialScholarship()
        {
            LabTask4Entities2 db = new LabTask4Entities2();
            var specialScholarship = (from b in db.Students
                where b.DOB.Year <= DateTime.Now.Year - 30 && b.Cgpa >= 3.50
                select b).ToList();
            return View(specialScholarship);

        }

        public ActionResult Scholarship()
        {
            LabTask4Entities2 db = new LabTask4Entities2();
            var scholarship = (from b in db.Students
                where  b.Cgpa >= 3.75
                select b).ToList();
            return View(scholarship);

        }
    }
}