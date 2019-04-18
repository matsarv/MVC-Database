using MVC_Database.Database;
using MVC_Database.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Models
{
    public class TeacherService : ITeacherService
    {
        readonly SchoolDBContext _schoolDBContext;

        public TeacherService(SchoolDBContext schoolDBContext)
        {
            _schoolDBContext = schoolDBContext;
        }

        // CREATE
        public Teacher CreateTeacher(Teacher teacher)
        {

            _schoolDBContext.Teachers.Add(teacher);
            _schoolDBContext.SaveChanges();

            return teacher;
        }

        //READ
        //all
        public List<Teacher> AllTeachers()
        {
            return _schoolDBContext.Teachers.ToList();
        }
        //one
        public Teacher FindTeacher(int id)
        { 
            return _schoolDBContext.Teachers.SingleOrDefault(Teacher => Teacher.ID == id);
        }

        // UPDATE
        public bool UpdateTeacher(Teacher teacher)
        {
            bool wasUpdated = false;

            Teacher orginal = _schoolDBContext.Teachers.SingleOrDefault(item => item.ID == teacher.ID);
            if (orginal != null)
            {
                orginal.FirstName = teacher.FirstName;
                orginal.LastName = teacher.LastName;
                orginal.Email = teacher.Email;

                _schoolDBContext.SaveChanges();
                wasUpdated = true;
            }

            return wasUpdated;
        }

        // DELETE
        public bool DeleteTeacher(int id)
        {
            bool wasRemoved = false;

            Teacher teacher = _schoolDBContext.Teachers.SingleOrDefault(teachers => teachers.ID == id);
            if (teacher == null)
            {
                return wasRemoved;
            }

            _schoolDBContext.Teachers.Remove(teacher);
            _schoolDBContext.SaveChanges();
            wasRemoved = true;

            return wasRemoved;
        }
    }
}
