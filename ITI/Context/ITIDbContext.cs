using ITI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Context
{
    internal class ITIDbContext : DbContext

    {
        public ITIDbContext():base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
          =>  optionsBuilder.UseSqlServer("Server=.;Database=EnterpriseDbContext;Trusted_Connection=True;TrustServerCertificate=True;");
        

        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Topic> Topics { get; set; }
       // public DbSet<Stud_Course> Stud_Courses { get; set; }
       // public DbSet<Course_Inst> Course_Insts { get; set; }


        

    }
}
