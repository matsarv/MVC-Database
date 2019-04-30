using MVC_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Interface
{

    public interface IStudentService
    {
        // CREATE
        Student CreateStudent(Student student);

        // READ
        //all
        List<Student> AllStudents();
        //one
        Student FindStudent(int id);

        Student SelectCoursesStudentAssignments(int id);

        // UPDATE
        bool UpdateStudent(Student student);

        // DELETE
        bool DeleteStudent(int id);
    }
}
