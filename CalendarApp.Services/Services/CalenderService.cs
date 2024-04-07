using AutoMapper;
using Repository.Entities;
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
using Microsoft.EntityFrameworkCore;

namespace CalendarApp.Services.Services
{
    public class CalenderService : ICalenderService
    {
        private readonly ICalenderRepository _calender;
        private readonly IMapper _mapper;
        private readonly ICalenderUserService _calenderUserService;

        public CalenderService(ICalenderRepository calender, ICalenderUserService calenderUser, IMapper mapper)
        {
            _calender = calender;
            _mapper = mapper;
            _calenderUserService = calenderUser;
        }

        public async Task<CalenderDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CalenderDTO>(await _calender.GetByIdAsync(id));
        }
       
        public async Task<CalenderDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<CalenderDTO>(await _calender.GetByIdAsync(id));
        }
        public async Task<IEnumerable<CalenderDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<CalenderDTO>>(await _calender.GetAllAsync());
        }

        public async Task<CalenderDTO> AddAsync(CalenderDTO calender)
        {
            Calender newCalender = await _calender.AddAsync(calender.DirectorId, calender.GroupName);
            return _mapper.Map<CalenderDTO>(newCalender);
        }

        public async Task<CalenderDTO> UpdateAsync(CalenderDTO calender)
        {
            return _mapper.Map<CalenderDTO>(await _calender.UpdateAsync(_mapper.Map<Calender>(calender)));
        }

        public async Task DeleteAsync(int id)
        {
            await _calender.DeleteAsync(id);
        }

        public async Task<IEnumerable<CalenderDTO>> GetCalendarsBySiteUserId(int siteUserId)
        {
            return _mapper.Map<IEnumerable<CalenderDTO>> (await _calender.GetCalendarsBySiteUserId(siteUserId));
        }
    }
}
