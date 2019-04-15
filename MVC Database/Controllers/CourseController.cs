 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Database.Interface;
using MVC_Database.Models;

namespace MVC_Database.Controllers
{
    public class CourseController : Controller
    {
        ICourseService _courseService;
        ITeacherService _teacherService;

        public CourseController(ICourseService courseService, ITeacherService teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
        }

        // GET
        public IActionResult Index()
        {
            return View(_courseService.AllCourses());
        }

        // GET
        public IActionResult Select(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //List<StudentCourse> course = _courseService.SelectCourse((int)id);
            Course course = _courseService.SelectCourse((int)id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _courseService.FindCourse((int)id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _courseService.FindCourse((int)id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _courseService.DeleteCourse(id);

            return RedirectToAction("Index");
        }

        // GET
        public IActionResult AddTeacherCourse(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _courseService.SelectCourseTeacher((int)id);

            if (course == null)
            {
                return NotFound();
            }

            List<Teacher> teachers = _teacherService.AllTeachers();

            if (teachers == null)
            {
                return NotFound();
            }

            CourseTeachersViewModel vm = new CourseTeachersViewModel();

            vm.course = course;
            vm.teachers = teachers;

            return View(vm);
        }

        // GET: 
        public ActionResult AddTeacherCourseSave(int teacherid, int id)
        {
            _courseService.AddTeacherCourseSave(teacherid,id);

            return RedirectToAction("Select", "Course", new { id });
        }

        // GET
        public IActionResult DeleteTeacherCourse(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _courseService.SelectCourse((int)id);

            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: 
        [HttpPost, ActionName("DeleteTeacherCourse")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeacherCourseConfirmed(int id)
        {
            _courseService.DeleteTeacherCourse(id);

            return RedirectToAction("Select", "Course", new { id });
        }

        // GET
        public IActionResult DeleteStudentCourse(int? studentid,int? id)
        {
            if (id == null || studentid == null)
            {
                return NotFound();
            }

            Course course = _courseService.SelectCourse((int)id);

            //course.StudentCourses;
            

            //????????????? 

            return View();

            

        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = _courseService.FindCourse((int)id);

            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ID,CourseNumber,Title,Description,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.UpdateCourse(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        //[HttpPost, ActionName("Create")]
        //public IActionResult Create(string firstName, string lastName, string email)
        public IActionResult Create([Bind("CourseNumber,Title,Description,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseService.CreateCourse(course);

                return RedirectToAction("Index");
            }

            return View(_courseService.AllCourses());

        }
    }
}