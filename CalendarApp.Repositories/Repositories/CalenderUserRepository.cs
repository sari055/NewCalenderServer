using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using CalendarApp.Repositories;
using CalendarApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Repositories
{
    public class CalenderUserRepository : ICalenderUserRepository
    {
        readonly IContext _context;

        public CalenderUserRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<CalenderUser> AddAsync(int userId, int calenderId ,UserType userType)
        {

            var newCalenderUser = new CalenderUser
            { 
                UserId = userId, 
                CalenderId = calenderId,
                UserType = userType
                //LevelId = levelId,
                //FamilyId = familyId
            } ;
            await _context.CalenderUsers.AddAsync(newCalenderUser);
            await _context.SaveChangesAsync();
            return newCalenderUser;
        }

        public async Task DeleteAsync(int id)
        {
            var calenderUser = await GetByIdAsync(id);
            _context.CalenderUsers.Remove(calenderUser);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<CalenderUser>> GetAllAsync()
        {
            return await _context.CalenderUsers.ToListAsync();
        }

        public async Task<CalenderUser> GetByIdAsync(int id)
        {
            return await _context.CalenderUsers.FindAsync(id);
        }

      
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<CalenderUser> UpdateAsync(CalenderUser calenderUser)
        {
            var updatedCalenderUser = _context.CalenderUsers.Update(calenderUser);
            await _context.SaveChangesAsync();
            return updatedCalenderUser.Entity;
        }

        
    }
}
