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
    public class CalenderUserService : ICalenderUserService
    {
        private readonly ICalenderUserRepository _calenderUser;
        private readonly IUserService _user;
        private readonly IMapper _mapper;

        public CalenderUserService(ICalenderUserRepository calenderUser, IUserService user, IMapper mapper)
        {
            _calenderUser = calenderUser;
            _mapper = mapper;
            _user = user;
        }

        public async Task<CalenderUserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CalenderUserDTO>(await _calenderUser.GetByIdAsync(id));
        }

        public async Task<IEnumerable<CalenderUserDTO>> GetListAsync(int userId)
        {
            List<UserDTO> users = (List<UserDTO>)await _user.getBySiteUserAsync(userId);
            //TODO: get calenders by userid
            return _mapper.Map<IEnumerable<CalenderUserDTO>>(await _calenderUser.GetAllAsync());
        }

        public async Task<CalenderUserDTO> AddAsync(CalenderUserDTO calenderUser)
        {
            
            return _mapper.Map<CalenderUserDTO>(await _calenderUser.AddAsync(calenderUser.UserId, calenderUser.CalenderId, _mapper.Map<UserType>(calenderUser.UserType)));
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
