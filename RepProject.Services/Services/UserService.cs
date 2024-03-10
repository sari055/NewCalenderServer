using AutoMapper;
using Repository.Entities;
using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using Repproject.Repositories.Repositories;
using RepProject.Common.DTOs;
using RepProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Azure.Core.HttpHeader;

namespace RepProject.Services.Services
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
    }
}
