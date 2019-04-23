using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Database.Interface;
using MVC_Database.Models;

namespace MVC_Database.Controllers
{
    public class AssignmentController : Controller
    {
        IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        // GET
        public IActionResult Index()
        {
            return View(_assignmentService.AllAssignments());
        }
        // GET
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment assignment= _assignmentService.FindAssignment((int)id);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment assignment = _assignmentService.FindAssignment((int)id);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _assignmentService.DeleteAssignment(id);

            return RedirectToAction("Index");
        }

        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment assignment = _assignmentService.FindAssignment((int)id);

            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }


        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("ID,AssignmentNumber,Title,Description,Email")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _assignmentService.UpdateAssignment(assignment);
                return RedirectToAction("Index");

            }

            return View(assignment);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        //[HttpPost, ActionName("Create")]
        public IActionResult Create([Bind("AssignmentNumber,Title,Description")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _assignmentService.CreateAssignment(assignment);
                return RedirectToAction("Index");

            }

            return View(_assignmentService.AllAssignments());

        }

    }
}