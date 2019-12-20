using CrudMVCPractice.Manager;
using CrudMVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudMVCPractice.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager = new StudentManager();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                string message = studentManager.Save(studentModel);
                ViewBag.message = message;
            }
            return View();
        }
        public ActionResult StudentDetails()
        {
            List<StudentModel> AllStudent = studentManager.GetAllStudent();
            return View(AllStudent);
        }
        public ActionResult Details(int id)
        {
            StudentModel specificStudent = studentManager.GetStudentById(id);
            return View(specificStudent);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentModel specificStudent = studentManager.GetStudentById(id);
            return View(specificStudent);
        }
        [HttpPost]
        public ActionResult Edit(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
               studentManager.UpdateStudentById(studentModel);
               
            }
            return RedirectToAction("StudentDetails");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            studentManager.DeleteById(id);
            
            return RedirectToAction("StudentDetails");
        }

    }
}