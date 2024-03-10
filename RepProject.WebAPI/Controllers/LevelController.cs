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
    public class LevelController : ControllerBase
    {
        readonly ILevelService _level;
      

        public LevelController(ILevelService level)
        {
            _level = level;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<LevelDTO>> Get()
        {
            return await _level.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<LevelDTO> GetById(int id)
        {
            return await _level.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _level.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] LevelModel order)
        {
          //  Debug.WriteLine(order.IdParent);

            await _level.AddAsync(new LevelDTO
            {  
                LevelName = order.LevelName,
                Sort = order.Sort,
            });
        }
        [HttpPut]
        public async Task Put(LevelDTO level)
        {
            await _level.UpdateAsync(level);
        }
        //[HttpGet("name/{name},adress/{adress}")]
        //public async Task<YearEventDTO> GetByDetails(string name,string adress)
        //{


        //    return await _level.GetOrderIdAsync(name,adress);
        //}
    }
}
