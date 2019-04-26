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

        // CREATE
        public Student CreateStudent(Student student)
        {

            _schoolDBContext.Students.Add(student);
            _schoolDBContext.SaveChanges();

            return student;
        }

        // READ
        // all
        public List<Student> AllStudents()
        {
            return _schoolDBContext.Students.ToList();
        }
        // one
        public Student FindStudent(int id)
        {
            return _schoolDBContext.Students.SingleOrDefault(Student => Student.ID == id);
        }

        // UPDATE
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

        // DELETE
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
