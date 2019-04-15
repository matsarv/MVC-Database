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
        //one with course, teacher, all student
        Course SelectCourse(int id);
        //one with course, all teacher
        Course SelectCourseTeacher(int id);



        // UPDATE
        bool UpdateCourse(Course course);
        //bool AddTeacherCourse(int id);
        bool AddTeacherCourseSave(int teacherid, int id);
        bool AddStudentCourseSave(int studentid, int id);

        // DELETE
        bool DeleteCourse(int id);
        bool DeleteTeacherCourse(int id);
        bool DeleteStudentCourse(int studentid, int id);
    }
}
