using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Security;
using RepProject.Repositories.Entities;
namespace RepProject.Context
{
    public class Context:DbContext
    {
        public DbSet <Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Claim> Claims { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=(sqlsrv)\\mssqllocaldb;Database=MyDatabase" +
                ";Trusted_Connection=True;");
        }
    }
}
