using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class CourseTeachersViewModel
    {
        public Course course { get; set; }
        public List<Teacher> teachers { get; set; }

    }
}
