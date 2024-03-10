using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repproject.Repositories;
using Repproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Repositories
{
    public class CalenderYearRepository : ICalenderYearRepository
    {
        readonly IContext _context;

        public CalenderYearRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<CalenderYear> AddAsync(int calenderId,int year)
        {
            var newCalenderYear = new CalenderYear
            { 
                CalenderId = calenderId,
                Year = year,
                } ;
            await _context.CalenderYears.AddAsync(newCalenderYear);
            await _context.SaveChangesAsync();
            return newCalenderYear;
        }

        public async Task DeleteAsync(int id)
        {
            var payment = await GetByIdAsync(id);
            _context.CalenderYears.Remove(payment);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<CalenderYear>> GetAllAsync()
        {
            return await _context.CalenderYears.ToListAsync();
        }

        public async Task<CalenderYear> GetByIdAsync(int id)
        {
            return await _context.CalenderYears.FindAsync(id);
        }

      
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<CalenderYear> UpdateAsync(CalenderYear calenderYear)
        {
            var updatedCalenderYear = _context.CalenderYears.Update(calenderYear);
            await _context.SaveChangesAsync();
            return updatedCalenderYear.Entity;
        }

        
    }
}
