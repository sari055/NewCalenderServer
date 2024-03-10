using Microsoft.EntityFrameworkCore;
 
using System;
using System.Data;
using System.Security;
using Repproject.Repositories;
using Repproject.Repositories.Interfaces;
using Repository.Entities;

namespace RepProject.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<YearEvent> YearEvents { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Calender> Calenders { get; set; }
        public DbSet<CalenderYear> CalenderYears { get; set; }
        public DbSet<CalenderUser> CalenderUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
           "Server=(localdb)\\mssqllocaldb;Database=Calender_DB;Trusted_Connection=True;");
        }
    }
}




































































