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
        [HttpGet]
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
            if (ModelState.IsValid)
            {

                LabTask4Entities2 db = new LabTask4Entities2();
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult SpecialScholarship()
        {
            LabTask4Entities2 db = new LabTask4Entities2();
            var specialScholarship = (from b in db.Students
                where b.DOB.Year <= DateTime.Now.Year - 30 && b.Cgpa >= 3.50
                select b).ToList();
            return View(specialScholarship);

        }

        [HttpGet]
        public ActionResult Scholarship()
        {
            LabTask4Entities2 db = new LabTask4Entities2();
            var scholarship = (from b in db.Students
                where b.Cgpa >= 3.75
                select b).ToList();
            return View(scholarship);

        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            LabTask4Entities2 db = new LabTask4Entities2();
            var student = (from b in db.Students
                where b.Id == id
                select b).FirstOrDefault();
            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(Student s)
        {
            LabTask4Entities2 db = new LabTask4Entities2();
            var dat2 = (from ss in db.Students
                where ss.Id == s.Id
                select ss).FirstOrDefault();

            //  data2.Cgpa = s.Cgpa;
            //  data2.DOB = s.DOB;
            //  data2.Name = s.Name;
            // data2.StudentId = s.StudentId;
            //  data2.Id = s.Id;
            //  data2.Dept = s.Dept;
            //  db.SaveChanges();

            db.Entry(dat2).CurrentValues.SetValues(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            LabTask4Entities2 db = new LabTask4Entities2();
            var student = (from b in db.Students
                where b.Id == id
                select b).FirstOrDefault();
            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            LabTask4Entities2 db = new LabTask4Entities2();
            var dat2 = (from ss in db.Students
                where ss.Id == s.Id
                select ss).FirstOrDefault();

            db.Students.Remove(dat2);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}