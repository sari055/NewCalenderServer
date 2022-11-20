using AutoMapper;
using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using RepProject.Common.DTOs;
using RepProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _role;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository role, IMapper mapper)
        {
            _role = role;
            _mapper = mapper;
        }

        public RoleDTO Add(int id, string name)
        {
            _role.Add(id, name);
            return new RoleDTO() { Id = id, Name = name };
        }

        public void Delete(int id)
        {
            _role.Delete(id);
        }

        public List<RoleDTO> GetAll()
        {
            return _mapper.Map<List<RoleDTO>>(_role.GetAll());
        }

        public RoleDTO GetById(int id)
        {
            return _mapper.Map<RoleDTO>(_role.GetById(id));
        }

        public RoleDTO Update(RoleDTO role)
        {
            _role.Update(_mapper.Map<Role>(role));
            return role;
        }
    }
}
