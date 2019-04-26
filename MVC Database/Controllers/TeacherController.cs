using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Database.Interface;
using MVC_Database.Models;

namespace MVC_Database.Controllers
{
    public class TeacherController : Controller
    {
        ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        // GET
        public IActionResult Index()
        {
            return View(_teacherService.AllTeachers());
        }

        // GET
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher teacher = _teacherService.FindTeacher((int)id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher teacher = _teacherService.FindTeacher((int)id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _teacherService.DeleteTeacher(id);

            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Teacher teacher = _teacherService.FindTeacher((int)id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ID,FirstName,LastName,Email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherService.UpdateTeacher(teacher);
                return RedirectToAction("Index");

            }

            return View(teacher);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,Email")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _teacherService.CreateTeacher(teacher);
                return RedirectToAction("Index");

            }

            return View(teacher);

        }
    }
}