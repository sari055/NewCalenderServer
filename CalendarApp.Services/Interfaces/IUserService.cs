using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarApp.Services.Models;
using System.IdentityModel.Tokens.Jwt;

namespace CalendarApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetListAsync();

        Task<UserDTO> GetByIdAsync(int id);

        Task<UserDTO> AddAsync(UserDTO user);

        Task<UserDTO> UpdateAsync(UserDTO user);

        Task DeleteAsync(int id);

        Task<UserDTO> GetByEmailAndPassword(string email, string password);
        Task<UserDTO> FindByEmailAsync(string userEmail);

    }
}
