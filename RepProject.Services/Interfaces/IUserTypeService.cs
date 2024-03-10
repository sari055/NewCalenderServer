using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Interfaces
{
    public interface IUserTypeService
    {
        Task<IEnumerable<UserTypeDTO>> GetListAsync();

        Task<UserTypeDTO> GetByIdAsync(int id);

        Task<UserTypeDTO> AddAsync(UserTypeDTO userType);

        Task<UserTypeDTO> UpdateAsync(UserTypeDTO userType);

        Task DeleteAsync(int id);
    }
}
