using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventDTO>> GetListAsync();

        Task<EventDTO> GetByIdAsync(int id);

        Task<EventDTO> AddAsync(EventDTO eevent);

        Task<EventDTO> UpdateAsync(EventDTO eevent);

        Task DeleteAsync(int id);
    }
}
