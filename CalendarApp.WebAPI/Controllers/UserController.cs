using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CalendarApp.Repositories.Entities;
using CalendarApp.Repositories.Interfaces;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using CalendarApp.WebAPI.Models;
using CalendarApp.WebAPI.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using CalendarApp.WebAPI.Helpers;


namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _user;
        readonly ITokenService _tokenService;

        public UserController(IUserService user, ITokenService tokenService)
        {
            _user = user;
            _tokenService = tokenService;
        }

        // GET: api/<RolesController>
        [Authorize]
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

        [HttpGet("login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            UserDTO user = await _user.GetByEmailAndPassword(email, password);

            if (user == null) return Unauthorized("Invalid UserName or password");

            user.UserPassword = string.Empty;

            var token = _tokenService.GenerateToken(user);

            return Ok(new { user, token});
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {

            //  Debug.WriteLine(order.IdParent);
            //Todo: create decreapted password
            var userWithSameEmail = await _user.FindByEmailAsync(user.UserEmail);
            if (userWithSameEmail != null)
            {
                return BadRequest(new { message = $"Email {user.UserEmail} is already registered." });
            }
            await _user.AddAsync(user);
            return Ok(user);
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
