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
    public class CalenderUserService : ICalenderUserService
    {
        private readonly ICalenderUserRepository _calenderUser;
        private readonly IMapper _mapper;

        public CalenderUserService(ICalenderUserRepository calenderUser, IMapper mapper)
        {
            _calenderUser = calenderUser;
            _mapper = mapper;
        }

        public async Task<CalenderUserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CalenderUserDTO>(await _calenderUser.GetByIdAsync(id));
        }
       
        public async Task<CalenderUserDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<CalenderUserDTO>(await _calenderUser.GetByIdAsync(id));
        }
        public async Task<IEnumerable<CalenderUserDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<CalenderUserDTO>>(await _calenderUser.GetAllAsync());
        }

        public async Task<CalenderUserDTO> AddAsync(CalenderUserDTO calenderUser)
        {
            
            return _mapper.Map<CalenderUserDTO>(await _calenderUser.AddAsync(calenderUser.UserId,calenderUser.UserType,calenderUser.LevelId,calenderUser.FamilyId));
        }

        public async Task<CalenderUserDTO> UpdateAsync(CalenderUserDTO calenderUser)
        {
            return _mapper.Map<CalenderUserDTO>(await _calenderUser.UpdateAsync(_mapper.Map<CalenderUser>(calenderUser)));
        }

        public async Task DeleteAsync(int id)
        {
            await _calenderUser.DeleteAsync(id);
        }
    }
}
