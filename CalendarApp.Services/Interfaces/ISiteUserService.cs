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
    public interface ISiteUserService
    {
        Task<IEnumerable<SiteUserDTO>> GetListAsync();

        Task<SiteUserDTO> GetByIdAsync(int id);

        Task<SiteUserDTO> AddAsync(SiteUserDTO user);
        Task<SiteUserDTO> Register(SiteUserDTO siteUser, UserDTO user, CalendarDTO calendar);

        Task<SiteUserDTO> UpdateAsync(SiteUserDTO user);

        Task DeleteAsync(int id);

        Task<SiteUserDTO> GetByEmailAndPassword(string email, string password);
        Task<SiteUserDTO> FindByEmailAsync(string email);

    }
}
