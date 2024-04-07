using Microsoft.EntityFrameworkCore;

using System;
using System.Data;
using System.Security;
using CalendarApp.Repositories;
using CalendarApp.Repositories.Interfaces;
using Repository.Entities;
using System.Linq;

namespace CalendarApp.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<YearEvent> YearEvents { get; set; }

        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<User> Users { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set relationships
            modelBuilder.Entity<Calender>()
                .HasMany(c => c.CalenderUsers)
                .WithOne(cu => cu.Calender)
                .HasForeignKey(cu => cu.CalenderId);

            modelBuilder.Entity<CalenderUser>()
                .HasOne(cu => cu.User)
                .WithOne(d => d.CalenderUser)
                .HasForeignKey<CalenderUser>(cu => cu.UserId);

            modelBuilder.Entity<CalenderUser>()
                .HasOne(cu => cu.User)
                .WithOne(d => d.CalenderUser)
                .HasForeignKey<CalenderUser>(cu => cu.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
               .HasOne(d => d.SiteUser)
               .WithMany(u => u.Users)
               .HasForeignKey(d => d.SiteUserId);

            modelBuilder.Entity<User>()
                .HasOne(d => d.Spouse)
                .WithOne()
                .HasForeignKey<User>(d => d.SpouseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(d => d.Father)
                .WithOne()
                .HasForeignKey<User>(d => d.FatherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(d => d.Mother)
                .WithOne()
                .HasForeignKey<User>(d => d.MotherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<YearEvent>()
                .HasOne(ye => ye.Event)
                .WithMany()
                .HasForeignKey(ye => ye.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            //convert enums to string
            modelBuilder.Entity<CalenderUser>().Property(u => u.UserType).HasConversion<string>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
