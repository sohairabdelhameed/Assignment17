using Assignment17.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment17.Context
{
    internal class EnterpriseDbContext : DbContext
    {
        public EnterpriseDbContext() : base() { }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{ 
        //    //optionsBuilder.UseSqlServer("Data source = . ; Intial Catlog = EnterpriseDbContext; Integrated Security = true;"); //OldWay
        //    optionsBuilder.UseSqlServer("Server = . ; Database = EnterpriseDbContext; Trusted-Connection = true;"); //New Way

        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        =>
         optionsBuilder.UseSqlServer("Server=.;Database=EnterpriseDbContext;Trusted_Connection=True;TrustServerCertificate=True;");

        public DbSet<Employee> Employees { get; set; }
        
    }
}
