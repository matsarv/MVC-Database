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
        
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name"),StringLength(50, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        //[StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        //[StringLength(50, MinimumLength = 1)]
        public string Email { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Enrollment Date")]
        //public DateTime EnrollmentDate { get; set; }

        //[Display(Name = "Full Name")]
        //public string FullName => LastName + " " + FirstName;

        //public virtual ICollection<Course> Courses { get; set; }
    }


}