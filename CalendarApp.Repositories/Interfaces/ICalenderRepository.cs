using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface ICalenderRepository
    {
        Task<List<Calender>> GetAllAsync();

        Task<Calender> GetByIdAsync(int id);
    
        Task<Calender> AddAsync( int directorId,string groupName);

        Task<Calender> UpdateAsync(Calender calender);

        Task<List<Calender>> GetCalendarsBySiteUserId(int siteUserId);
        Task DeleteAsync(int id);
    }
}

