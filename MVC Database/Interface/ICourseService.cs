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

        // Create
        Course CreateCourse(Course course);

        // Read
        //all
        List<Course> AllCourses();
        //one
        Course FindCourse(int id);

        // Update
        bool UpdateCourse(Course course);

        // Delete
        bool DeleteCourse(int id);

    }
}
