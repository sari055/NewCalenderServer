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
    public class UserTypeRepository : IUserTypeRepository
    {
        readonly IContext _context;

        public UserTypeRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<UserType> AddAsync(string name)
        {
            var newUserType = new UserType
            { 
                Name = name,
            } ;
            await _context.UserTypes.AddAsync(newUserType);
            await _context.SaveChangesAsync();
            return newUserType;
        }

        public async Task DeleteAsync(int id)
        {
            var userType = await GetByIdAsync(id);
            _context.UserTypes.Remove(userType);
            await _context.SaveChangesAsync();
            
        }

        public async Task<List<UserType>> GetAllAsync()
        {
            return await _context.UserTypes.ToListAsync();
        }

        public async Task<UserType> GetByIdAsync(int id)
        {
            return await _context.UserTypes.FindAsync(id);
        }

      
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<UserType> UpdateAsync(UserType userType)
        {
            var updatedUserType = _context.UserTypes.Update(userType);
            await _context.SaveChangesAsync();
            return updatedUserType.Entity;
        }

        
    }
}
