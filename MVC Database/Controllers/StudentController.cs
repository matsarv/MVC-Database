using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Database.Database;
using MVC_Database.Interface;
using MVC_Database.Models;

namespace MVC_Database.Controllers
{
    public class StudentController : Controller
    {
        IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET
        public IActionResult Index()
        {
            return View(_studentService.AllStudents());
        }

        // GET
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student student = _studentService.FindStudent((int)id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student student = _studentService.FindStudent((int)id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _studentService.DeleteStudent(id);

            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student student = _studentService.FindStudent((int)id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ID,FirstName,LastName,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.UpdateStudent(student);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.CreateStudent(student);

                return RedirectToAction("Index");
            }

            return View(student);

        }
    }
    
}