using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repproject.Repositories.Entities;
using RepProject.Common.DTOs;
using RepProject.Services.Interfaces;
using RepProject.Services.Services;
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
    public class CalenderUserController : ControllerBase
    {
        readonly ICalenderUserService _calenderUser;
      

        public CalenderUserController(ICalenderUserService calenderUser)
        {
            _calenderUser = calenderUser;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<CalenderUserDTO>> Get()
        {
            return await _calenderUser.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<CalenderUserDTO> GetById(int id)
        {
            return await _calenderUser.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _calenderUser.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] CalenderUserModel calenderUser)
        {
          //  Debug.WriteLine(order.IdParent);

            await _calenderUser.AddAsync(new CalenderUserDTO
            {  
                FamilyId = calenderUser.FamilyId,
                LevelId = calenderUser.LevelId,
                UserId = calenderUser.UserId,
                UserType = calenderUser.UserType,
            });
        }
        [HttpPut]
        public async Task Put(CalenderUserDTO calenderUser)
        {
            await _calenderUser.UpdateAsync(calenderUser);
        }
        //[HttpGet("name/{name},adress/{adress}")]
        //public async Task<YearEventDTO> GetByDetails(string name,string adress)
        //{


        //    return await _order.GetOrderIdAsync(name,adress);
        //}
    }
}
