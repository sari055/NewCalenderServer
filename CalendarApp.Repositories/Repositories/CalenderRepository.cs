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
    public class CalenderRepository : ICalenderRepository
    {
        readonly IContext _context;

        public CalenderRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<Calender> AddAsync(int directorId,string groupName)
        {
            var newCalender = new Calender
            { 
                DirectorId = directorId,    
                GroupName = groupName
                } ;
            await _context.Calenders.AddAsync(newCalender);
            await _context.SaveChangesAsync();
            return newCalender;
        }

        public async Task DeleteAsync(int id)
        {
            var calender = await GetByIdAsync(id);
            _context.Calenders.Remove(calender);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Calender>> GetAllAsync()
        {
            return await _context.Calenders.ToListAsync();
        }

        public async Task<Calender> GetByIdAsync(int id)
        {
            return await _context.Calenders.FindAsync(id);
        }

      
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<Calender> UpdateAsync(Calender calender)
        {
            var updatedCalender = _context.Calenders.Update(calender);
            await _context.SaveChangesAsync();
            return updatedCalender.Entity;
        }

        
    }
}
