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

        public int AssignmentID { get; set; }

        public int CourseID { get; set; }

        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public string Grade { get; set; }
        //public Grade? Grade { get; set; }

        //public virtual Course Course { get; set; }
        //public virtual Student Student { get; set; }


    }
}
