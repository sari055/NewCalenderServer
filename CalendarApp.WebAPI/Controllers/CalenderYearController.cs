using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using CalendarApp.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderYearController : ControllerBase
    {
        readonly ICalenderYearService _calenderYear;
      

        public CalenderYearController(ICalenderYearService calenderYear)
        {
            _calenderYear = calenderYear;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<CalenderYearDTO>> Get()
        {
            return await _calenderYear.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<CalenderYearDTO> GetById(int id)
        {
            return await _calenderYear.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _calenderYear.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] CalenderYearModel calenderYear)
        {
          //  Debug.WriteLine(order.IdParent);

            await _calenderYear.AddAsync(new CalenderYearDTO
            {  
                 CalenderId=calenderYear.CalenderId,
                 Year=calenderYear.Year,
            });
        }
        [HttpPut]
        public async Task Put(CalenderYearDTO calenderYear)
        {
            await _calenderYear.UpdateAsync(calenderYear);
        }
        //[HttpGet("name/{name},adress/{adress}")]
        //public async Task<YearEventDTO> GetByDetails(string name,string adress)
        //{


        //    return await _order.GetOrderIdAsync(name,adress);
        //}
    }
}
