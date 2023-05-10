using Repproject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IChildRepository
    {
        Task<List<Child>> GetAllAsync();

        Task<Child> GetByIdAsync(int id);
     //   Task<int> GetByTzAsync(string tz);

        Task<Child> AddAsync( string name, DateTime dateOfBirth,string tz,int idParent);

        Task<Child> UpdateAsync(Child child);

        Task DeleteAsync(int id);
    }
}
