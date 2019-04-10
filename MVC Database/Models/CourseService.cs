using Microsoft.EntityFrameworkCore;
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

            // Test below

            //return _schoolDBContext.Courses
            //        .Where(b => b.Description.Contains("Age"))
            //        .ToList();

            //return _schoolDBContext.Courses
            //        .FromSql("SELECT * FROM dbo.Courses")
            //        .ToList();

            //var test = _schoolDBContext.Courses
            //            //.Where(s => s.CourseID == id)
            //            .Include(s => s.StudentCourses)
            //                .ThenInclude(g => g.Student)
            //                .ToList();
            //return test;

            //var test = _schoolDBContext.Courses
            //            .Where(s => s.ID == 1)
            //            .Include(sc => sc.StudentCourses)
            //                .ThenInclude(s => s.Student)
            //                .Include(t => t.Teacher)
            //                .ToList();
            //return test;
        }

        public List<StudentCourse> SelectCourse(int id)
        {
            Course course = _schoolDBContext.Courses.SingleOrDefault(x => x.ID == id);

            course.StudentCourses = _schoolDBContext.StudentCourses

            .Include(x => x.Course.StudentCourses)
                .ThenInclude(x => x.Student)
            .Where(x => x.CourseId == course.ID)
            //.ThenInclude(x => x.Course)

            .Include(x => x.Course)
                .ThenInclude(x => x.Teacher)
            .Where(x => x.CourseId == course.ID)

            //.OrderByDescending(x => x.Student)
            //.AsNoTracking()
            .ToList();

            return course.StudentCourses;


            //https://www.entityframeworktutorial.net/efcore/querying-in-ef-core.aspx
            //https://blog.oneunicorn.com/2017/09/25/many-to-many-relationships-in-ef-core-2-0-part-1-the-basics/

            //var test = _schoolDBContext.Courses
            ////.Where(s => s.CourseID == id)
            //.Include(s => s.StudentCourses)
            //                .ThenInclude(g => g.Student)
            //                .ToList();
            //return test;

            //var test = _schoolDBContext.Courses
            //            .Where(s => s.ID == id)
            //            .Include(sc => sc.StudentCourses)
            //                .ThenInclude(s => s.Student)
            //                .Include(t => t.Teacher)
            //                .ToList();
            //return test;

            //var test = _schoolDBContext.StudentCourses
            //.Where(s => s.CourseId == id)
            //.Include(sc => sc.Course)
            //    .ThenInclude(s => s.Student)
            //    .Include(t => t.Teacher)
            //    .ToList();
            //return test;



            //return _schoolDBContext.Courses.SingleOrDefault(Course => Course.ID == id);
        }


        public Course CreateCourse(Course course)
        {

            _schoolDBContext.Courses.Add(course);
            _schoolDBContext.SaveChanges();

            return course;
        }

        public Course FindCourse(int id)
        {
            return _schoolDBContext.Courses.SingleOrDefault(item => item.ID == id);
        }

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
