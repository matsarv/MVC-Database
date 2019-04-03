using MVC_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Interface
{

    public interface IStudentService
    {

        // CRUD

        // Create
        //Student CreateStudent(string firstName, string lastName, string email);
        Student CreateStudent(Student student);

        // Read
        //all
        List<Student> AllStudents();
        //one
        Student FindStudent(int id);

        // Update
        bool UpdateStudent(Student student);

        // Delete
        bool DeleteStudent(int id);

    }
}
