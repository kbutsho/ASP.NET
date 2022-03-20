using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(Student s)
        {
            var db = new APIEntities();
            var user = new Student();
            user.Id = s.Id;
            user.Name = s.Name;
            user.CGPA = s.CGPA;
            db.Students.Add(user);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Added Successfully");

        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            APIEntities db = new APIEntities();
            var student = (from b in db.Students select b).ToList();
            return Request.CreateResponse( HttpStatusCode.OK, student);
        }
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            APIEntities db = new APIEntities();
            var student = (from b in db.Students
                where b.Id == id
                select b).FirstOrDefault();

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }
        [HttpPut]
        public HttpResponseMessage Put(Student s)
        {
            APIEntities db = new APIEntities();
            var student = (from b in db.Students
                where b.Id == s.Id
                select b).FirstOrDefault();

            student.Name = s.Name;
            student.CGPA = s.CGPA;
            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Update Successfully");
        }
        [HttpDelete]
        public HttpResponseMessage Delete(Student s)
        {
            APIEntities db = new APIEntities();
            var student = (from b in db.Students
                where b.Id == s.Id
                select b).FirstOrDefault();

            db.Students.Remove(student);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Delete Successfully");
        }
    }
}
