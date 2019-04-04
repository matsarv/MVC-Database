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

        public List<Teacher> AllTeachers()
        {
            return _schoolDBContext.Teachers.ToList();
        }


        public Teacher CreateTeacher(Teacher teacher)
        {
            //Student student = new Student() { FirstName = firstName, LastName= lastName, Email= email };

            _schoolDBContext.Teachers.Add(teacher);
            _schoolDBContext.SaveChanges();

            return teacher;
        }

        public Teacher FindTeacher(int id)
        { 
            return _schoolDBContext.Teachers.SingleOrDefault(Teacher => Teacher.ID == id);
            //foreach (Student item in _schoolDBContext.Students)
            //{
            //    if (item.ID == id)
            //    {
            //        return item;
            //    }
            //}

            //return null;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            bool wasUpdated = false;

            Teacher orginal = _schoolDBContext.Teachers.SingleOrDefault(teachers => teachers.ID == teacher.ID);
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
