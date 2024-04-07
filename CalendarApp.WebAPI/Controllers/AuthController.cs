﻿using Microsoft.AspNetCore.Http;
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
    public class AuthController : ControllerBase
    {
        readonly ISiteUserService _siteUser;
        readonly ITokenService _tokenService;

        public AuthController(ISiteUserService user, ITokenService tokenService)
        {
            _siteUser = user;
            _tokenService = tokenService;
        }

        // GET: api/<RolesController>
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<SiteUserDTO>> Get()
        {
            return await _siteUser.GetListAsync();
        }

        [HttpGet("{id}")]
        public async Task<SiteUserDTO> GetById(int id)
        {
            return await _siteUser.GetByIdAsync(id);
        }

        [HttpDelete]
        public async Task Delete(int id)
        {
            await _siteUser.DeleteAsync(id);
        }

        [HttpGet("login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            SiteUserDTO siteUser = await _siteUser.GetByEmailAndPassword(email, password);

            if (siteUser == null) return Unauthorized("שם משתמש או סיסמה שגויים");

            siteUser.Password = string.Empty;

            var token = _tokenService.GenerateToken(siteUser);

            return Ok(new { siteUser, token});
        }

        [HttpPost("register")]
        public async Task<ActionResult<SiteUserDTO>> Post([FromBody] AuthModel request)
        {
            var userWithSameEmail = await _siteUser.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
            {
                return BadRequest(new { message = $"המייל {request.Email} כבר קיים במערכת" });
            }
            await _siteUser.Register(request.SiteUser, request.User, request.Calender);
            return Ok();
        }

        [HttpPut]
        public async Task Put(SiteUserDTO siteUser)
        {
            await _siteUser.UpdateAsync(siteUser);
        }
        
    }
}
