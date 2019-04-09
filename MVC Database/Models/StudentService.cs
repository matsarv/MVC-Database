using MVC_Database.Database;
using MVC_Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MVC_Database.Models
{
    public class StudentService : IStudentService
    {

        readonly SchoolDBContext _schoolDBContext;

        public StudentService(SchoolDBContext schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
        }

        public List<Student> AllStudents()
        {
            return _schoolDBContext.Students.ToList();

            //var stud1 = _schoolDBContext.Students
            //   .Include("StudentCourses")
            //   .Where(s => s.FirstName == "Mats1")
            //   .FirstOrDefault<Student>();

            //return stud1.ToList();

            //     var nestedQuery = from s in _schoolDBContext.Students
            //                       from c in s.StudentCourses
            //                       where s.ID == 1
            //                       select new { s.FirstName, c };

            //     var nestedQuery = nestedQuery.ToList();         


            ////     var student = _schoolDBContext.Students
            ////                     .Where(s => s.FirstName == "Mats1").ToList();
            ////     //.FirstOrDefault<Student>();

            ////     _schoolDBContext.Entry(student)
            ////.Collection(s => s.StudentCourses)
            ////.Query()
            ////    .Where(sc => sc.CourseID == "1000")
            ////    .FirstOrDefault();

            //     return nestedQuery;

        }


        public Student CreateStudent(Student student)
        {
            //Student student = new Student() { FirstName = firstName, LastName= lastName, Email= email };

            _schoolDBContext.Students.Add(student);
            _schoolDBContext.SaveChanges();

            return student;
        }

        public Student FindStudent(int id)
        {
            return _schoolDBContext.Students.SingleOrDefault(Student => Student.ID == id);

            //foreach (Student item in _schoolDBContext.Students)
            //{
            //    if (item.ID == id)
            //    {
            //        return item;
            //    }
            //}

            //return null;
        }

        public bool UpdateStudent(Student student)
        {
            bool wasUpdated = false;

            Student orginal = _schoolDBContext.Students.SingleOrDefault(item => item.ID == student.ID);
            if (orginal != null)
            {
                orginal.FirstName = student.FirstName;
                orginal.LastName = student.LastName;
                orginal.Email = student.Email;

                _schoolDBContext.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;
        }

        public bool DeleteStudent(int id)
        {
            bool wasRemoved = false;

            Student student = _schoolDBContext.Students.SingleOrDefault(students => students.ID == id);
            if (student == null)
            {
                return wasRemoved;
            }

            _schoolDBContext.Students.Remove(student);
            _schoolDBContext.SaveChanges();
            wasRemoved = true;

            return wasRemoved;
        }
    }
}
