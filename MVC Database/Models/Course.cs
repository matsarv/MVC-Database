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
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Credits")]
        public int Credits { get; set; }


        //public Student AssignedTo { get; set; }

        //public virtual ICollection<Assignment> Assignments { get; set; }
        //public virtual ICollection<Teacher> Teachers { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }


    }
}
