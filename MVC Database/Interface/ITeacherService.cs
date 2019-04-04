using MVC_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Interface
{
    public interface ITeacherService
    {
        // CRUD

        // Create
        Teacher CreateTeacher(Teacher teacher);

        // Read
        //all
        List<Teacher> AllTeachers();
        //one
        Teacher FindTeacher(int id);

        // Update
        bool UpdateTeacher(Teacher teacher);

        // Delete
        bool DeleteTeacher(int id);

    }
}
