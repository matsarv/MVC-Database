using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class Teacher
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        //[StringLength(50, MinimumLength = 1)]
        [Display(Name = "First Name")]
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
        ////[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Hire Date")]
        //public DateTime HireDate { get; set; }

        [Display(Name = "Name")]
        public string FullName => LastName + " " + FirstName;

        public List<Course> Courses { get; set; }

    }
}
