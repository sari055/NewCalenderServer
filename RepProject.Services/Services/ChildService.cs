using AutoMapper;
using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using Repproject.Repositories.Repositories;
using RepProject.Common.DTOs;
using RepProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepProject.Services.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _child;
        private readonly IMapper _mapper;

        public ChildService(IChildRepository child, IMapper mapper)
        {
            _child = child;
            _mapper = mapper;
        }

        public async Task<ChildDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<ChildDTO>(await _child.GetByIdAsync(id));
        }
        public async Task<ChildDTO> GetParentIdAsync(int id)
        {
            return _mapper.Map<ChildDTO>(await _child.GetByIdAsync(id));
        }

        public async Task<IEnumerable<ChildDTO>> GetListAsync()
        {
            //לוגיקה עסקית
            return _mapper.Map<IEnumerable<ChildDTO>>(await _child.GetAllAsync());
        }

        public async Task<ChildDTO> AddAsync(ChildDTO child)
        {
            
            return _mapper.Map<ChildDTO>(await _child.AddAsync(child.Name,child.DateOfBirth,child.Tz,child.IdParent));
        }

        public async Task<ChildDTO> UpdateAsync(ChildDTO child)
        {
            return _mapper.Map<ChildDTO>(await _child.UpdateAsync(_mapper.Map<Child>(child)));
        }

        public async Task DeleteAsync(int id)
        {
            await _child.DeleteAsync(id);
        }
    }
}
