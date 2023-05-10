using AutoMapper;
using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using RepProject.Common.DTOs;
using RepProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Services
{
    public class PrentService : IParentService
    {
        private readonly IParentRepository _parent;
        private readonly IMapper _mapper;

        public PrentService(IParentRepository parent, IMapper mapper)
        {
            _parent = parent;
            _mapper = mapper;
        }

        public async Task<ParentDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<ParentDTO>(await _parent.GetByIdAsync(id));
        }
        public async Task<int> GetByTzAsync(string tz)
        {
            return _mapper.Map<int>(await _parent.GetByTzAsync(tz));
        }

        public async Task<IEnumerable<ParentDTO>> GetListAsync()
        {
            //לוגיקה עסקית
            return _mapper.Map<IEnumerable<ParentDTO>>(await _parent.GetAllAsync());
        }

        public async Task<ParentDTO> AddAsync(ParentDTO parent)
        {
            return _mapper.Map<ParentDTO>(await _parent.AddAsync( parent.FirstName,parent.LastName,parent.DateOfBirth,parent.Tz,parent.Type,parent.HMO ));
        }
        public async Task<string> CreateTzAsync(string tz)
        {
            return _mapper.Map<string>(await _parent.CreateTzAsync(tz));
        }

        public async Task<ParentDTO> UpdateAsync(ParentDTO parent)
        {
            return _mapper.Map<ParentDTO>(await _parent.UpdateAsync(_mapper.Map<Parent>(parent)));
        }

        public async Task DeleteAsync(int id)
        {
            await _parent.DeleteAsync(id);
        }
    }
}
