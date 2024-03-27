using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Services.Interfaces
{
    public interface ICalenderYearService
    {
        Task<IEnumerable<CalenderYearDTO>> GetListAsync();

        Task<CalenderYearDTO> GetByIdAsync(int id);

        Task<CalenderYearDTO> AddAsync(CalenderYearDTO calenderYear);

        Task<CalenderYearDTO> UpdateAsync(CalenderYearDTO calenderYear);

        Task DeleteAsync(int id);
    }
}
