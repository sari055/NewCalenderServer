using AutoMapper;
using Repository.Entities;
using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using Repproject.Repositories.Repositories;
using RepProject.Common.DTOs;
using RepProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace RepProject.Services.Services
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _level;
        private readonly IMapper _mapper;

        public LevelService(ILevelRepository level, IMapper mapper)
        {
            _level = level;
            _mapper = mapper;
        }

        public async Task<LevelDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<LevelDTO>(await _level.GetByIdAsync(id));
        }
       
        public async Task<LevelDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<LevelDTO>(await _level.GetByIdAsync(id));
        }
        public async Task<IEnumerable<LevelDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<LevelDTO>>(await _level.GetAllAsync());
        }

        public async Task<LevelDTO> AddAsync(LevelDTO level)
        {
            
            return _mapper.Map<LevelDTO>(await _level.AddAsync(level.LevelName,level.Sort));
        }

        public async Task<LevelDTO> UpdateAsync(LevelDTO level)
        {
            return _mapper.Map<LevelDTO>(await _level.UpdateAsync(_mapper.Map<Level>(level)));
        }

        public async Task DeleteAsync(int id)
        {
            await _level.DeleteAsync(id);
        }
    }
}
