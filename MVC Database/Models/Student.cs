using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name"), StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[DataType(DataType.Date)]
        ////[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Enrollment Date")]
        //public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Name")]
        public string FullName => LastName + " " + FirstName;

        public IList<StudentCourse> StudentCourses { get; set; }


    }


}