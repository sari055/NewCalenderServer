using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CalendarApp.Repositories.Entities;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using CalendarApp.Services.Services;
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
    public class UserTypeController : ControllerBase
    {
        readonly IUserTypeService _userType;
      

        public UserTypeController(IUserTypeService userType)
        {
            _userType = userType;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<UserTypeDTO>> Get()
        {
            return await _userType.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<UserTypeDTO> GetById(int id)
        {
            return await _userType.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _userType.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] UserTypeModel userType)
        {
          //  Debug.WriteLine(order.IdParent);

            await _userType.AddAsync(new UserTypeDTO
            {  
                Name = userType.Name,
            });
        }
        [HttpPut]
        public async Task Put(UserTypeDTO userType)
        {
            await _userType.UpdateAsync(userType);
        }
      //  [HttpGet("name/{name},adress/{adress}")]
        //public async Task<UserTypeDTO> GetByDetails(string name,string adress)
        //{


        //    return await _userType.GetOrderIdAsync(name,adress);
        //}
    }
}
