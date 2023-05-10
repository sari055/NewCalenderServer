using RepProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Interfaces
{
    public interface IParentService
    {

        Task<IEnumerable<ParentDTO>> GetListAsync();

        Task<ParentDTO> GetByIdAsync(int id);
       Task<int> GetByTzAsync(string tz);

        Task<ParentDTO> AddAsync(ParentDTO parent);
        Task<string> CreateTzAsync(string tz);

        Task<ParentDTO> UpdateAsync(ParentDTO parent);

        Task DeleteAsync(int id);
    }
}
