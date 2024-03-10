using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Interfaces
{
    public interface ICalenderUserService
    {
        Task<IEnumerable<CalenderUserDTO>> GetListAsync();

        Task<CalenderUserDTO> GetByIdAsync(int id);

        Task<CalenderUserDTO> AddAsync(CalenderUserDTO calenderUser);

        Task<CalenderUserDTO> UpdateAsync(CalenderUserDTO calenderUser);

        Task DeleteAsync(int id);
    }
}
