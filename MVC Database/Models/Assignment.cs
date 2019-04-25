using MVC_Database.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class Assignment
    {
        //public enum Grade
        //{
        //    A, B, C, D, E
        //}

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseID { get; set; }

        [Required]
        [Display(Name = "Assignment Number")]
        public int AssignmentNumber { get; set; }

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

        //[DisplayFormat(NullDisplayText = "No grade")]
        //public string Grade { get; set; }
        //public Grade? Grade{ get; set; }

        //public virtual Course Course { get; set; }

        
        

    }
}
