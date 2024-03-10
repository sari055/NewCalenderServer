using Repository.Entities;
using Repproject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();

        Task<Event> GetByIdAsync(int id);
    
        Task<Event> AddAsync(   int calenderId,string eventType,string hebrewDate, int userId,string eventYear ,bool oneTimeEvent);

        Task<Event> UpdateAsync(Event eevent);
        

        Task DeleteAsync(int id);
    }
}

