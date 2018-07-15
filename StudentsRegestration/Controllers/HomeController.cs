using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentsRegestration.Models;

namespace StudentsRegestration.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCourses()
        {

            var courses = new Courses().GetData();
            JsonResult jsonResult = Json(new { data = courses }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }


        [HttpGet]
        public JsonResult GetStudents()
        {

            var courses = new Student().GetData();
            JsonResult jsonResult = Json(new { data = courses }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetRegitrationData()
        {

            var courses = new Registration().GetData();
            JsonResult jsonResult = Json(new { data = courses }, JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult Register(int CourseID, int StudentID)
        {

            var services = new Registration().Register(CourseID, StudentID) ;
            JsonResult jsonResult = Json(new { data = services }, JsonRequestBehavior.AllowGet);
            return jsonResult;
            

        }
    }
}