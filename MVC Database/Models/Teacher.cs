using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class Teacher
    {
        public int Id { get; set; }

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

        //[Display(Name = "Full Name")]
        //public string FullName => LastName + " " + FirstName;


    }
}
