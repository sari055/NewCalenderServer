using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface ILevelRepository
    {
        Task<List<Level>> GetAllAsync();

        Task<Level> GetByIdAsync(int id);
    
        Task<Level> AddAsync( string levelName, int sort);

        Task<Level> UpdateAsync(Level Level);
        

        Task DeleteAsync(int id);
    }
}

