using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Entities;
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
    public class YearEventController : ControllerBase
    {
        readonly IYearEventService _yearEvent;
      

        public YearEventController(IYearEventService yearEvent)
        {
            _yearEvent = yearEvent;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<YearEventDTO>> Get()
        {
            return await _yearEvent.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<YearEventDTO> GetById(int id)
        {
            return await _yearEvent.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _yearEvent.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] YearEventModel yearEvent)
        {
          //  Debug.WriteLine(order.IdParent);

            await _yearEvent.AddAsync(new YearEventDTO
            {  
                EventId = yearEvent.EventId,
                CalenderId = yearEvent.CalenderId,
                GregorianDate = yearEvent.GregorianDate,
            });
        }
        [HttpPut]
        public async Task Put(YearEventDTO payment)
        {
            await _yearEvent.UpdateAsync(payment);
        }
    }
}
