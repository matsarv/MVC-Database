using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class CourseAssigmentsViewModel
    {
        public Course course { get; set; }
        public List<Assignment> assignments { get; set; }
    }
}
