using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class CourseStudentsViewModel
    {
        public Course course { get; set; }
        public List<Student> students { get; set; }
    }
}
