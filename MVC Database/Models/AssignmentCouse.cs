using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class AssignmentCouse
    {
        [Key]
        public int ID { get; set; }
        public string AssignmentID { get; set; }
        public string CourseID { get; set; }
    }
}
