﻿using Microsoft.AspNetCore.Http;
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
    public class EventController : ControllerBase
    {
        readonly IEventService _eevent;
      

        public EventController(IEventService eevent)
        {
            _eevent = eevent;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<EventDTO>> Get()
        {
            return await _eevent.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<EventDTO> GetById(int id)
        {
            return await _eevent.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _eevent.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] EventModel eevent)
        {
          //  Debug.WriteLine(order.IdParent);

            await _eevent.AddAsync(new EventDTO
            {  
               CalenderId = eevent.CalenderId,
               EventType = eevent.EventType,
               EventYear = eevent.EventYear,
               HebrewDate = eevent.HebrewDate,
               OneTimeEvent = eevent.OneTimeEvent,
               UserId = eevent.UserId,
            });
        }
        [HttpPut]
        public async Task Put(EventDTO eevent)
        {
            await _eevent.UpdateAsync(eevent);
        }
      //  [HttpGet("name/{name},adress/{adress}")]
        //public async Task<YearEventDTO> GetByDetails(string name,string adress)
        //{


        //    return await _eevent.GetOrderIdAsync(name,adress);
        //}
    }
}
