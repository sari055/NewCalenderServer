using Repository.Entities;
using CalendarApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetByIdAsync(int id);

        Task<User> GetByEmailAndPassword(string email, string password);

        Task<User> AddAsync(   int userTZ , int userSpouseID ,  int userFatherID,int userMotherID , string userName ,string userPhoneNumber, string userEmail,string userPassword);

        Task<User> UpdateAsync(User user);
        

        Task DeleteAsync(int id);
        Task<User> FindByEmailAsync(string userEmail);
    }
}

