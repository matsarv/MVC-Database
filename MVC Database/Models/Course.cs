using MVC_Database.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseNumber { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Credits")]
        public int Credits { get; set; }

        public List<StudentCourse> StudentCourses { get; set; }

        public Teacher Teacher {get; set;}

        public List<Assignment> Assignment { get; set; }

    }
}
