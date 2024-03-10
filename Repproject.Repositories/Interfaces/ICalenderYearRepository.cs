using Repository.Entities;
using Repproject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface ICalenderYearRepository
    {
        Task<List<CalenderYear>> GetAllAsync();

        Task<CalenderYear> GetByIdAsync(int id);
    
        Task<CalenderYear> AddAsync( int calenderId,int year);

        Task<CalenderYear> UpdateAsync(CalenderYear calenderYear);
        

        Task DeleteAsync(int id);
    }
}

