using MVC_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Interface
{
    public interface ICourseService
    {
        // CRUD

        // CREATE
        Course CreateCourse(Course course);

        // READ
        //all
        List<Course> AllCourses();
        //one
        Course FindCourse(int id);
        //one with all
        //List<StudentCourse> SelectCourse(int id);
        Course SelectCourse(int id);

        // UPDATE
        bool UpdateCourse(Course course);

        // DELETE
        bool DeleteCourse(int id);

    }
}
