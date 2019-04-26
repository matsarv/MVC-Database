using MVC_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Interface
{
    public interface IAssignmentService
    {
        // CREATE
        Assignment CreateAssignment(Assignment assignment);

        // READ
        //all
        List<Assignment> AllAssignments();
        //one
        Assignment FindAssignment(int id);

        // UPDATE
        bool UpdateAssignment(Assignment assignment);

        // DELETE
        bool DeleteAssignment(int id);
    }
}
