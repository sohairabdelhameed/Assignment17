using ITI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Context
{
    public class ITIDbContext : DbContext

    {
        public ITIDbContext():base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
          =>  optionsBuilder.UseSqlServer("Server=.;Database=EnterpriseDbContext;Trusted_Connection=True;TrustServerCertificate=True;");


        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Stud_Course> Stud_Courses { get; set; }
        public DbSet<Course_Inst> Course_Insts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Student-Department Relationship (Many-to-One)
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Department)
                .WithMany(d => d.Students)
                .HasForeignKey(s => s.Dep_Id);

            // Instructor-Department Relationship (Many-to-One)
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.Dept_ID);

            // Course-Topic Relationship (Many-to-One)
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Topic)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.Top_ID);

            // Student-Course Relationship (Many-to-Many)
            modelBuilder.Entity<Stud_Course>()
                .HasKey(sc => new { sc.stud_ID, sc.Course_ID });
            modelBuilder.Entity<Stud_Course>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Stud_Courses)
                .HasForeignKey(sc => sc.stud_ID);
            modelBuilder.Entity<Stud_Course>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.Stud_Courses)
                .HasForeignKey(sc => sc.Course_ID);

            // Instructor-Course Relationship (Many-to-Many)
            modelBuilder.Entity<Course_Inst>()
                .HasKey(ci => new { ci.inst_ID, ci.Course_ID });
            modelBuilder.Entity<Course_Inst>()
                .HasOne(ci => ci.Instructor)
                .WithMany(i => i.Course_Insts)
                .HasForeignKey(ci => ci.inst_ID);
            modelBuilder.Entity<Course_Inst>()
                .HasOne(ci => ci.Course)
                .WithMany(c => c.Course_Insts)
                .HasForeignKey(ci => ci.Course_ID);
        }




    }
}
