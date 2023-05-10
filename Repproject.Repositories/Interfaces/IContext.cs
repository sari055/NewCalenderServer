using Repproject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 

namespace Repproject.Repositories.Interfaces
{
	public interface IContext
	{

		DbSet<Child> Children { get; set; }
		DbSet<Parent> Parents { get; set; }
		int SaveChanges();
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}
