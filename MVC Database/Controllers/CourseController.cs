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
        IStudentService _studentService;
        IAssignmentService _assignmentService;

        public CourseController(ICourseService courseService, ITeacherService teacherService, IStudentService studentService, IAssignmentService assignmentService)
        {
            _courseService = courseService;
            _teacherService = teacherService;
            _studentService = studentService;
            _assignmentService = assignmentService;
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
        public IActionResult DeleteConfirmed(int id)
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
        public IActionResult AddTeacherCourseSave(int teacherid, int id)
        {
            _courseService.AddTeacherCourseSave(teacherid, id);

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
        public IActionResult DeleteTeacherCourseConfirmed(int id)
        {
            _courseService.DeleteTeacherCourse(id);

            return RedirectToAction("Select", "Course", new { id });
        }

        // GET
        public IActionResult AddStudentCourse(int? id)
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

            List<Student> students = _studentService.AllStudents();

            if (students == null)
            {
                return NotFound();
            }

            foreach (var item in course.StudentCourses)
            {
                students.Remove(item.Student);
            }

            CourseStudentsViewModel vm = new CourseStudentsViewModel();

            vm.course = course;
            vm.students = students;

            return View(vm);
        }

        // GET: 
        public IActionResult AddStudentCourseSave(int studentid, int id)
        {
            _courseService.AddStudentCourseSave(studentid, id);

            return RedirectToAction("Select", "Course", new { id });
        }

        // GET
        public IActionResult DeleteStudentCourse(int? studentid, int? id)
        {
            if (id == null || studentid == null)
            {
                return NotFound();
            }

            Course course = _courseService.SelectCourse((int)id);

            StudentCourse studentcourse = null;

            foreach (var item in course.StudentCourses)
            {
                if (item.StudentId == studentid)
                {
                    studentcourse = item;
                    break;
                }
            }

            return View(studentcourse);

        }

        //POST: 
        [HttpPost, ActionName("DeleteStudentCourse")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteStudentCourseConfirmed(int? studentid, int? courseid, int? id)
        {
            _courseService.DeleteStudentCourse((int)studentid, (int)courseid);

            return RedirectToAction("Select", "Course", new { id });
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
        public IActionResult Create([Bind("CourseNumber,Title,Description,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {

                _courseService.CreateCourse(course);

                return RedirectToAction("Index");
            }

            return View(_courseService.AllCourses());

        }



        //GET
        public IActionResult AddAssignmentsCourse(int? id)
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

            //_schoolDBContext.Assignments.ToList();
            List<Assignment> assignments = _assignmentService.AllAssignments();

            if (assignments == null)
            {
                return NotFound();
            }

            //foreach (var item in assignments)
            //{
            //    if (item.CourseID != (int)id)
            //    {
            //        assignments.Remove(item);
            //    }
            //}


            CourseAssigmentsViewModel vm = new CourseAssigmentsViewModel();

            vm.course = course;
            vm.assignments = assignments;

            return View(vm);
        }

        //GET 
        public IActionResult DeleteAssignmentCourse(int? assignmentid, int? id)
        {
            _assignmentService.DeleteAssignment((int)assignmentid);

            return RedirectToAction("AddAssignmentsCourse", "Course", new { id });

        }
        //[HttpPost, ActionName("DeleteAssignmentCourse")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteAssignmentCourseSave(int? assignmnetid, int courseid, int? id)
        //{
        //    //_courseService.DeleteAssignmentCourse((int)assignmnetid, (int)courseid);

        //    return RedirectToAction("Select", "Course", new { id });
        //}
    }


}