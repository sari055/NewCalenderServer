using AutoMapper;
using Repository.Entities;
using CalendarApp.Repositories.Entities;
using CalendarApp.Repositories.Interfaces;
using CalendarApp.Repositories.Repositories;
using CalendarApp.Common.DTOs;
using CalendarApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;
using CalendarApp.Services.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CalendarApp.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;

        public UserService(IUserRepository user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _user.GetByIdAsync(id));
        }
       
        public async Task<UserDTO> GetOrderIdAsync(int id)
        {
            return _mapper.Map<UserDTO>(await _user.GetByIdAsync(id));
        }
        public async Task<IEnumerable<UserDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _user.GetAllAsync());
        }

        public async Task<UserDTO> AddAsync(UserDTO user)
        {
            
            return _mapper.Map<UserDTO>(await _user.AddAsync(user.UserTZ, user.UserSpouseID,user.UserFatherID,user.UserMotherID,user.UserName,user.UserPhoneNumber,user.UserEmail,user.UserPassword));
        }

        public async Task<UserDTO> UpdateAsync(UserDTO user)
        {
            return _mapper.Map<UserDTO>(await _user.UpdateAsync(_mapper.Map<User>(user)));
        }

        public async Task DeleteAsync(int id)
        {
            await _user.DeleteAsync(id);
        }

        public async Task<UserDTO> GetByEmailAndPassword(string email, string password)
        {
            return _mapper.Map<UserDTO>(await _user.GetByEmailAndPassword(email, password));
        }

        public async Task<UserDTO> FindByEmailAsync(string userEmail)
        {
            return _mapper.Map<UserDTO>(await _user.FindByEmailAsync(userEmail));
        }
    }
}
