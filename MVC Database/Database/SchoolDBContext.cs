using Microsoft.EntityFrameworkCore;
using MVC_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Database.Database
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
               .HasOne<Course>(sc => sc.Course)
               .WithMany(s => s.StudentCourses)
               .HasForeignKey(sc => sc.StudentId);
        }



    }


}

