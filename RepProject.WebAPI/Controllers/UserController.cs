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
    public class UserController : ControllerBase
    {
        readonly IUserService _user;
      

        public UserController(IUserService user)
        {
            _user = user;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await _user.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<UserDTO> GetById(int id)
        {
            return await _user.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _user.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] UserModel order)
        {
          //  Debug.WriteLine(order.IdParent);

            await _user.AddAsync(new UserDTO
            {  
                UserTZ = order.UserTZ,
                UserEmail = order.UserEmail,
                UserFatherID = order.UserFatherID,
                UserMotherID = order.UserMotherID,
                UserName = order.UserName,
                UserPassword = order.UserPassword,
                UserPhoneNumber = order.UserPhoneNumber,
                UserSpouseID = order.UserSpouseID,
            });
        }
        [HttpPut]
        public async Task Put(UserDTO user)
        {
            await _user.UpdateAsync(user);
        }
        //[HttpGet("name/{name},adress/{adress}")]
        //public async Task<UserDTO> GetByDetails(string name,string adress)
        //{


        //    return await _user.GetOrderIdAsync(name,adress);
        //}
    }
}
