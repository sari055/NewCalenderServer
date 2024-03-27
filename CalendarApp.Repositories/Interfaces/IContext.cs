using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace CalendarApp.Repositories.Interfaces
{
	public interface IContext
	{

		DbSet<YearEvent> YearEvents { get; set; }
		DbSet<UserType> UserTypes { get; set; }
		DbSet<User> Users { get; set; }
		DbSet<Level> Levels { get; set; }	
		DbSet<Event> Events { get; set; }
		DbSet<Calender> Calenders { get; set; }
		DbSet<CalenderUser> CalenderUsers { get; set; }
		DbSet<CalenderYear> CalenderYears { get; set; }
		
		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
