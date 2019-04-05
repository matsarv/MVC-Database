using MVC_Database.Database;
using MVC_Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class CourseService : ICourseService
    {
        readonly SchoolDBContext _schoolDBContext;

        public CourseService(SchoolDBContext schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
        }

        public List<Course> AllCourses()
        {
            return _schoolDBContext.Courses.ToList();
        }


        public Course CreateCourse(Course course)
        {

            _schoolDBContext.Courses.Add(course);
            _schoolDBContext.SaveChanges();

            return course;
        }

        public Course FindCourse(int id)
        {
            return _schoolDBContext.Courses.SingleOrDefault(Course => Course.ID == id);
        }

        public bool UpdateCourse(Course course)
        {
            bool wasUpdated = false;

            Course orginal = _schoolDBContext.Courses.SingleOrDefault(item => item.ID == course.ID);
            if (orginal != null)
            {
                orginal.CourseID = course.CourseID;
                orginal.Title = course.Title;
                orginal.Description = course.Description;
                orginal.Credits = course.Credits;

                _schoolDBContext.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;
        }

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
