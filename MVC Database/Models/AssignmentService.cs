using MVC_Database.Database;
using MVC_Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class AssignmentService : IAssignmentService
    {
        readonly SchoolDBContext _schoolDBContext;

        public AssignmentService(SchoolDBContext schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
        }

        // CREATE
        public Assignment CreateAssignment(Assignment assignment)
        {
            _schoolDBContext.Assignments.Add(assignment);
            _schoolDBContext.SaveChanges();

            return assignment;
        }
        // READ
        // all
        public List<Assignment> AllAssignments()
        {
            return _schoolDBContext.Assignments.ToList();
        }
        // one
        public Assignment FindAssignment(int id)
        {
            return _schoolDBContext.Assignments.SingleOrDefault(Assignment => Assignment.ID == id);
        }
        // UPDATE
        public bool UpdateAssignment(Assignment assignment)
        {
            bool wasUpdated = false;

            Assignment orginal = _schoolDBContext.Assignments.SingleOrDefault(item => item.ID == assignment.ID);
            if (orginal != null)
            {
                orginal.CourseID = assignment.CourseID;
                orginal.AssignmentNumber = assignment.AssignmentNumber;
                orginal.Title = assignment.Title;
                orginal.Description = assignment.Description;
                orginal.Credits = assignment.Credits;

                _schoolDBContext.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;
        }
        // DELETE
        public bool DeleteAssignment(int id)
        {
            bool wasRemoved = false;

            Assignment assignment = _schoolDBContext.Assignments.SingleOrDefault(assignments => assignments.ID == id);
            if (assignment == null)
            {
                return wasRemoved;
            }

            _schoolDBContext.Assignments.Remove(assignment);
            _schoolDBContext.SaveChanges();
            wasRemoved = true;

            return wasRemoved;
        }

    }
}
