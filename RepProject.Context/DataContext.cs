using Microsoft.EntityFrameworkCore;
 
using System;
using System.Data;
using System.Security;
using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;

namespace RepProject.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<Child> Children { get; set; }
       public DbSet<Parent> Parents { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
           "Server=(localdb)\\mssqllocaldb;Database=Practicum_db;Trusted_Connection=True;");
        }

        

    }
}




































































