using Repository.Entities;
using Repproject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IUserTypeRepository
    {
        Task<List<UserType>> GetAllAsync();

        Task<UserType> GetByIdAsync(int id);
    
        Task<UserType> AddAsync( string name);

        Task<UserType> UpdateAsync(UserType userType);
        

        Task DeleteAsync(int id);
    }
}

