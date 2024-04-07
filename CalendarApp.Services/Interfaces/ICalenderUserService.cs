using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Services.Interfaces
{
    public interface ICalenderUserService
    {
        Task<IEnumerable<CalenderUserDTO>> GetListAsync(int userId);

        Task<CalenderUserDTO> GetByIdAsync(int id);

        Task<CalenderUserDTO> AddAsync(CalenderUserDTO calenderUser);

        Task<CalenderUserDTO> UpdateAsync(CalenderUserDTO calenderUser);

        Task DeleteAsync(int id);
    }
}
