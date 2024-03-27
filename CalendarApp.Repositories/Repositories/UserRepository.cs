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
    public class UserRepository : IUserRepository
    {
        readonly IContext _context;

        public UserRepository(IContext context)
        {
            _context = context;
        }
       
        public async Task<User> AddAsync(int userTZ, int userSpouseID, int userFatherID, int userMotherID, string userName, string userPhoneNumber, string userEmail, string userPassword)
        {
            var newUser = new User
            { 
                UserTZ=userTZ,
                UserSpouseID=userSpouseID,
                UserFatherID=userFatherID,
                UserMotherID=userMotherID,
                UserName=userName,
                UserPhoneNumber=userPhoneNumber,     
                UserEmail=userEmail,
                UserPassword=userPassword

               } ;
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<User> FindByEmailAsync(string userEmail)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserEmail == userEmail);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserEmail == email && user.UserPassword == password);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

      
        //public async Task<int> GetByTzAsync(string tz)
        //{
        //    var parentsList = await GetAllAsync();
        //    return parentsList.Find(u => u.Tz == tz).Id;
       
        //}
        public async Task<User> UpdateAsync(User user)
        {
            var updatedUser = _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return updatedUser.Entity;
        }

        
    }
}
