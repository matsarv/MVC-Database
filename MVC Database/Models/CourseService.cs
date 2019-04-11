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
            _schoolDBContext.Courses.Add(course);
            _schoolDBContext.SaveChanges();

            return course;
        }

        //READ
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
        // one with all
        public Course SelectCourse(int id)
        {
            var result = _schoolDBContext.Courses
            .Include(sc => sc.StudentCourses)
                .ThenInclude(s => s.Student)
            .Include(t => t.Teacher)
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
    }
}
