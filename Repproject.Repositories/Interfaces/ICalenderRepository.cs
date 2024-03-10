using Repository.Entities;
using Repproject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface ICalenderRepository
    {
        Task<List<Calender>> GetAllAsync();

        Task<Calender> GetByIdAsync(int id);
    
        Task<Calender> AddAsync( int directorId,string groupName);

        Task<Calender> UpdateAsync(Calender calender);
        

        Task DeleteAsync(int id);
    }
}

