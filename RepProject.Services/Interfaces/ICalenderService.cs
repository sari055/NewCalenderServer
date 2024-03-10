using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Interfaces
{
    public interface ICalenderService
    {
        Task<IEnumerable<CalenderDTO>> GetListAsync();

        Task<CalenderDTO> GetByIdAsync(int id);

        Task<CalenderDTO> AddAsync(CalenderDTO calender);

        Task<CalenderDTO> UpdateAsync(CalenderDTO calender);

        Task DeleteAsync(int id);
    }
}
