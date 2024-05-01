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
using CalendarApp.Repositories.Entities;

namespace CalendarApp.Services.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly ICalendarRepository _calendar;
        private readonly IMapper _mapper;
        private readonly ICalendarUserService _calendarUserService;

        public CalendarService(ICalendarRepository calendar, ICalendarUserService calendarUser, IMapper mapper)
        {
            _calendar = calendar;
            _mapper = mapper;
            _calendarUserService = calendarUser;
        }

        public async Task<CalendarDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CalendarDTO>(await _calendar.GetByIdAsync(id));
        }

        public async Task<CalendarDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<CalendarDTO>(await _calendar.GetByIdAsync(id));
        }
        public async Task<IEnumerable<CalendarDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<CalendarDTO>>(await _calendar.GetAllAsync());
        }

        public async Task<CalendarDTO> AddAsync(CalendarDTO calendar)
        {
            Calendar newCalendar = await _calendar.AddAsync(calendar.DirectorId, calendar.GroupName);
            return _mapper.Map<CalendarDTO>(newCalendar);
        }

        public async Task<CalendarDTO> UpdateAsync(CalendarDTO calendar)
        {
            return _mapper.Map<CalendarDTO>(await _calendar.UpdateAsync(_mapper.Map<Calendar>(calendar)));
        }

        public async Task DeleteAsync(int id)
        {
            await _calendar.DeleteAsync(id);
        }

        public async Task<IEnumerable<CalendarDTO>> GetCalendarsBySiteUserId(int siteUserId)
        {
            return _mapper.Map<IEnumerable<CalendarDTO>>(await _calendar.GetCalendarsBySiteUserId(siteUserId));
        }

        public async Task<IEnumerable<CalendarUserDTO>> GetUsersByCalendar(int siteUserId, int calendarId)
        {
            return _mapper.Map<IEnumerable<CalendarUserDTO>>(await _calendar.GetUsersByCalendar(siteUserId, calendarId));
        }
    }
}
