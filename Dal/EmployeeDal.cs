using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Dal
{
    public class EmployeeDal : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RQ1JV2J;Initial Catalog=EmployeeDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // what is your primary
            modelBuilder.Entity<EmployeeModel>().HasKey(p => p.id);
            modelBuilder.Entity<Address>().HasKey(p => p.id);
            //identity yes or now
            modelBuilder.Entity<EmployeeModel>().Property(t => t.id)
                .ValueGeneratedNever();

            // class maps with which table
            modelBuilder.Entity<EmployeeModel>()
                .ToTable("tblEmployee");

            modelBuilder.Entity<Address>()
               .ToTable("tblAddress");

            //1 to many
           
                modelBuilder.Entity<EmployeeModel>()
                    .HasMany(c => c.addresses)
                    .WithOne(e => e.employee);
            

            //Mapper. //Mapping



        }
        public DbSet<EmployeeModel> EmployeeModels { get; set; }
 
    }
}
