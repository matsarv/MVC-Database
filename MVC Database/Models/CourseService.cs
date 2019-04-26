using Microsoft.EntityFrameworkCore;
using MVC_Database.Database;
using MVC_Database.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Database.Models
{
    public class CourseService : ICourseService
    {
        readonly SchoolDBContext _schoolDBContext;

        public CourseService(SchoolDBContext schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
        }

        // CREATE
        public Course CreateCourse(Course course)
        {
            //var coursenumber = _schoolDBContext.Courses
            //.SingleOrDefault(x => x.CourseNumber == course.CourseNumber);

            //if (coursenumber == null)
            //{
                _schoolDBContext.Courses.Add(course);
                _schoolDBContext.SaveChanges();
                return course;
            //}
            //else
            //{
                
            //}

            //return course;
        }

        // READ
        // one
        public Course FindCourse(int id)
        {
            return _schoolDBContext.Courses.SingleOrDefault(item => item.ID == id);
        }
        // all
        public List<Course> AllCourses()
        {
            return _schoolDBContext.Courses.ToList();
        }
        // one course, teacher, all students 
        public Course SelectCourse(int id)
        {
            var result = _schoolDBContext.Courses
                        .Include(sc => sc.StudentCourses)
                            .ThenInclude(s => s.Student)
                        .Include(t => t.Teacher)
                        .Include(a => a.Assignment)
                        .SingleOrDefault(x => x.ID == id);

            return result;
        }
        // one course, all teachers
        public Course SelectCourseTeacher(int id)
        {
            var result = _schoolDBContext.Courses
                        .Include(t => t.Teacher)
                        .SingleOrDefault(x => x.ID == id);

            return result;
        }
        // one course, all students
        public Course SelectCourseStudent(int id)
        {
            var result = _schoolDBContext.Courses
                        .Include(sc => sc.StudentCourses)
                            .ThenInclude(s => s.Student)
                        .SingleOrDefault(x => x.ID == id);

            return result;
        }

        // UPDATE
        public bool UpdateCourse(Course course)
        {
            bool wasUpdated = false;

            Course orginal = _schoolDBContext.Courses.SingleOrDefault(item => item.ID == course.ID);
            if (orginal != null)
            {
                orginal.CourseNumber = course.CourseNumber;
                orginal.Title = course.Title;
                orginal.Description = course.Description;
                orginal.Credits = course.Credits;

                _schoolDBContext.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;
        }

        public bool AddTeacherCourseSave(int teacherid, int courseid)
        {
            bool wasUpdated = false;

            var course = _schoolDBContext.Courses
                        .Include(x => x.Teacher)
                        .SingleOrDefault(x => x.ID == courseid);

            var teacher = _schoolDBContext.Teachers
                        .SingleOrDefault(x => x.ID == teacherid);

            if (course != null)
            {
                course.Teacher = teacher;
                _schoolDBContext.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;
        }

        public bool AddStudentCourseSave(int studentid, int courseid)
        {
            bool wasUpdated = false;

            var course = _schoolDBContext.Courses
            .SingleOrDefault(x => x.ID == courseid);

            var student = _schoolDBContext.Students
            .SingleOrDefault(x => x.ID == studentid);

            if (course != null || student != null)
            {
                StudentCourse studentcourse = new StudentCourse() { StudentId = studentid, CourseId = courseid, Student = student, Course = course };

                var result = _schoolDBContext.StudentCourses.Add(studentcourse);
                _schoolDBContext.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;
        }

        // DELETE
        public bool DeleteCourse(int id)
        {
            bool wasRemoved = false;

            Course course = _schoolDBContext.Courses.SingleOrDefault(courses => courses.ID == id);
            if (course == null)
            {
                return wasRemoved;
            }

            _schoolDBContext.Courses.Remove(course);
            _schoolDBContext.SaveChanges();
            wasRemoved = true;

            return wasRemoved;
        }

        public bool DeleteTeacherCourse(int id)
        {
            bool wasRemoved = false;

            var course = _schoolDBContext.Courses
                        .Include(t => t.Teacher)
                        .SingleOrDefault(x => x.ID == id);

            if (course == null)
            {
                return wasRemoved;
            }

            if (course.Teacher != null)
            {
                course.Teacher = null;
                _schoolDBContext.SaveChanges();
                wasRemoved = true;
            }

            return wasRemoved;
        }

        public bool DeleteStudentCourse(int studentid, int courseid)
        {
            bool wasRemoved = false;

            Course course = SelectCourse((int)courseid);

            foreach (var item in course.StudentCourses)
            {
                if (item.StudentId == studentid)
                {
                    _schoolDBContext.StudentCourses.Remove(item);
                    _schoolDBContext.SaveChanges();
                    wasRemoved = true;
                    break;
                }
            }

            return wasRemoved;
        }

        //public bool DeleteAssignmentCourse(int assignmentid, int id)
        //{
        //    bool wasRemoved = false;



        //    return wasRemoved;
        //}
    }
}