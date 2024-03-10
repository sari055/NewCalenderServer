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
    public class LevelRepository : ILevelRepository
    {
        readonly IContext _context;

        public LevelRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<Level> AddAsync(string levelName,int sort)
        {
            var newLevel = new Level
            { 
                LevelName = levelName,
                Sort = sort
               } ;
            await _context.Levels.AddAsync(newLevel);
            await _context.SaveChangesAsync();
            return newLevel;
        }

        public async Task DeleteAsync(int id)
        {
            var level = await GetByIdAsync(id);
            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<Level>> GetAllAsync()
        {
            return await _context.Levels.ToListAsync();
        }

        public async Task<Level> GetByIdAsync(int id)
        {
            return await _context.Levels.FindAsync(id);
        }

      
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<Level> UpdateAsync(Level level)
        {
            var updatedLevel = _context.Levels.Update(level);
            await _context.SaveChangesAsync();
            return updatedLevel.Entity;
        }

        
    }
}
