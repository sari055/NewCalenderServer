using Repproject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IParentRepository
    {
       
       Task<int> GetByTzAsync(string tz);
        Task<List<Parent>> GetAllAsync();
        Task<string> CreateTzAsync(string tz);
        Task<Parent> GetByIdAsync(int id);

        Task<Parent> AddAsync(string firstName,string lastName,DateTime dateOfBirth,string tz,string type,string hMO);

        Task<Parent> UpdateAsync(Parent parent);

        Task DeleteAsync(int id);
    }
}
