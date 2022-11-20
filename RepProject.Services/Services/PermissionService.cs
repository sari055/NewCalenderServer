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
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permission;
        private readonly IMapper _mapper;

        public PermissionService(IPermissionRepository permission, IMapper mapper)
        {
            _permission = permission;
            _mapper = mapper;
        }

        public PermissionDTO Add(int id, string name)
        {
            _permission.Add(id, name);
            return new PermissionDTO { Id = id, Name = name };
        }

        public void Delete(int id)
        {
            _permission.Delete(id);
        }

        public List<PermissionDTO> GetAll()
        {
            return _mapper.Map<List<PermissionDTO>>(_permission.GetAll());
        }

        public PermissionDTO GetById(int id)
        {

            return _mapper.Map<PermissionDTO>(_permission.GetById(id));
        }

        public PermissionDTO Update(PermissionDTO permission)
        {
            _permission.Update(_mapper.Map<Permission>(permission));
            return permission;
        }
    }
}
