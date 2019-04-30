using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class StudentCoursesAssignmentsViewModel
    {
        public Student Student { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
