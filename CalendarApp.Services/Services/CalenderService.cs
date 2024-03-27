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
    public class CalenderService : ICalenderService
    {
        private readonly ICalenderRepository _calender;
        private readonly IMapper _mapper;

        public CalenderService(ICalenderRepository calender, IMapper mapper)
        {
            _calender = calender;
            _mapper = mapper;
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
            
            return _mapper.Map<CalenderDTO>(await _calender.AddAsync(calender.DirectorId,calender.GroupName));
        }

        public async Task<CalenderDTO> UpdateAsync(CalenderDTO calender)
        {
            return _mapper.Map<CalenderDTO>(await _calender.UpdateAsync(_mapper.Map<Calender>(calender)));
        }

        public async Task DeleteAsync(int id)
        {
            await _calender.DeleteAsync(id);
        }
    }
}
