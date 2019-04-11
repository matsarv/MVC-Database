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

        // CRETAE
        Teacher CreateTeacher(Teacher teacher);

        // READ
        //all
        List<Teacher> AllTeachers();
        //one
        Teacher FindTeacher(int id);

        // UPDATE
        bool UpdateTeacher(Teacher teacher);

        // DELETE
        bool DeleteTeacher(int id);

    }
}
