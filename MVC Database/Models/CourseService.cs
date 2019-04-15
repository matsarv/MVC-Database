﻿using Microsoft.EntityFrameworkCore;
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

        // CRUD

        // CREATE
        public Course CreateCourse(Course course)
        {
            _schoolDBContext.Courses.Add(course);
            _schoolDBContext.SaveChanges();

            return course;
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
        // one with course, teacher, all students 
        public Course SelectCourse(int id)
        {
            var result = _schoolDBContext.Courses
                        .Include(sc => sc.StudentCourses)
                            .ThenInclude(s => s.Student)
                        .Include(t => t.Teacher)
                        .SingleOrDefault(x => x.ID == id);

            return result;
        }
        // one with course, all teachers
        public Course SelectCourseTeacher(int id)
        {
            var result = _schoolDBContext.Courses
                        //.Include(sc => sc.StudentCourses)
                        //    .ThenInclude(s => s.Student)
                        .Include(t => t.Teacher)
                        .SingleOrDefault(x => x.ID == id);
         

            return result;
        }

        public StudentCourse SelectStudentCourse (int studentid, int id)
        {
            var result =_schoolDBContext.StudentCourses
                         .SingleOrDefault(x => x.StudentId == studentid);


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

        public bool AddTeacherCourseSave(int teacherid, int id)
        {
            bool wasUpdated = false;

            var course = _schoolDBContext.Courses
                        .Include(t => t.Teacher)
                        .SingleOrDefault(x => x.ID == id);

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

        public bool AddStudentCourseSave(int studentid, int id)
        {
            bool wasUpdated = false;



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

        public bool DeleteStudentCourse(int studentid, int id)
        {
            bool wasRemoved = false;

            //var course = _schoolDBContext.Courses
            //.Include(t => t.Teacher)
            //.SingleOrDefault(x => x.ID == id);

            wasRemoved = true;
            return wasRemoved;
        }
    }
}
