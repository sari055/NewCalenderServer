using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using RepProject.Services.Interfaces;
using RepProject.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace RepProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalenderController : ControllerBase
    {
        readonly ICalenderService _calender;
      

        public CalenderController(ICalenderService calender)
        {
            _calender = calender;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<CalenderDTO>> Get()
        {
            return await _calender.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<CalenderDTO> GetById(int id)
        {
            return await _calender.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _calender.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] CalenderModel calender)
        {
          //  Debug.WriteLine(order.IdParent);

            await _calender.AddAsync(new CalenderDTO
            {  
              DirectorId=calender.DirectorId,
              GroupName=calender.GroupName,
            });
        }
        [HttpPut]
        public async Task Put(CalenderDTO calender)
        {
            await _calender.UpdateAsync(calender);
        }
        //[HttpGet("name/{name},adress/{adress}")]
        //public async Task<CalenderDTO> GetByDetails(string name,string adress)
        //{


        //    return await _calender.GetOrderIdAsync(name,adress);
        //}
    }
}
