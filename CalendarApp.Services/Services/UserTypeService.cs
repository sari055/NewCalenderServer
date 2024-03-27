using AutoMapper;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Repositories.Interfaces;
using CalendarApp.Repositories.Repositories;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace CalendarApp.Services.Services
{
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeRepository _userType;
        private readonly IMapper _mapper;

        public UserTypeService(IUserTypeRepository userType, IMapper mapper)
        {
            _userType = userType;
            _mapper = mapper;
        }

        public async Task<UserTypeDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<UserTypeDTO>(await _userType.GetByIdAsync(id));
        }
       
        public async Task<UserTypeDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<UserTypeDTO>(await _userType.GetByIdAsync(id));
        }
        public async Task<IEnumerable<UserTypeDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<UserTypeDTO>>(await _userType.GetAllAsync());
        }

        public async Task<UserTypeDTO> AddAsync(UserTypeDTO userType)
        {
            
            return _mapper.Map<UserTypeDTO>(await _userType.AddAsync(userType.Name));
        }

        public async Task<UserTypeDTO> UpdateAsync(UserTypeDTO userType)
        {
            return _mapper.Map<UserTypeDTO>(await _userType.UpdateAsync(_mapper.Map<UserType>(userType)));
        }

        public async Task DeleteAsync(int id)
        {
            await _userType.DeleteAsync(id);
        }
    }
}
