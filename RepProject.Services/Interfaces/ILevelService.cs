using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Interfaces
{
    public interface ILevelService
    {
        Task<IEnumerable<LevelDTO>> GetListAsync();

        Task<LevelDTO> GetByIdAsync(int id);

        Task<LevelDTO> AddAsync(LevelDTO level);

        Task<LevelDTO> UpdateAsync(LevelDTO level);

        Task DeleteAsync(int id);
    }
}
