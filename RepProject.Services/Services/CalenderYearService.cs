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
    public class CalenderYearService : ICalenderYearService
    {
        private readonly ICalenderYearRepository _calenderYear;
        private readonly IMapper _mapper;

        public CalenderYearService(ICalenderYearRepository calenderYear, IMapper mapper)
        {
            _calenderYear = calenderYear;
            _mapper = mapper;
        }

        public async Task<CalenderYearDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CalenderYearDTO>(await _calenderYear.GetByIdAsync(id));
        }
       
        public async Task<CalenderYearDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<CalenderYearDTO>(await _calenderYear.GetByIdAsync(id));
        }
        public async Task<IEnumerable<CalenderYearDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<CalenderYearDTO>>(await _calenderYear.GetAllAsync());
        }

        public async Task<CalenderYearDTO> AddAsync(CalenderYearDTO calenderYear)
        {
            
            return _mapper.Map<CalenderYearDTO>(await _calenderYear.AddAsync(calenderYear.CalenderId,calenderYear.Year));
        }

        public async Task<CalenderYearDTO> UpdateAsync(CalenderYearDTO calenderYear)
        {
            return _mapper.Map<CalenderYearDTO>(await _calenderYear.UpdateAsync(_mapper.Map<CalenderYear>(calenderYear)));
        }

        public async Task DeleteAsync(int id)
        {
            await _calenderYear.DeleteAsync(id);
        }
    }
}
