using MVC_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Interface
{
    public interface ICourseService
    {
        // CREATE
        Course CreateCourse(Course course);

        // READ
        //all course
        List<Course> AllCourses();
        //one course
        Course FindCourse(int id);
        //one course, teacher, all students
        Course SelectCourse(int id);
        //one course, all teacher
        Course SelectCourseTeacher(int id);

        // UPDATE
        bool UpdateCourse(Course course);
        bool AddTeacherCourseSave(int teacherid, int id);
        bool AddStudentCourseSave(int studentid, int id);

        // DELETE
        bool DeleteCourse(int id);
        bool DeleteTeacherCourse(int id);
        bool DeleteStudentCourse(int studentid, int id);
        //bool DeleteAssignmentCourse(int assignmentid, int id);
    }
}
