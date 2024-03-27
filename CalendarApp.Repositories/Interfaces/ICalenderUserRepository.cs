using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface ICalenderUserRepository
    {
        Task<List<CalenderUser>> GetAllAsync();

        Task<CalenderUser> GetByIdAsync(int id);
    
        Task<CalenderUser> AddAsync( int userId,string userType ,int levelId,int familyId);

        Task<CalenderUser> UpdateAsync(CalenderUser calenderUser);
        

        Task DeleteAsync(int id);
    }
}

