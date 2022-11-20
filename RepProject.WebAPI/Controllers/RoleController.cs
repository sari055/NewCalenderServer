using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepProject.Common.DTOs;
using RepProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly IRoleService _roles;

        public RoleController(IRoleService roles)
        {
            _roles = roles;
        }

        [HttpGet]
        public List<RoleDTO> GetAll()
        {
            return _roles.GetAll();
        }

        [HttpGet("{id}")]
        public RoleDTO Get(int id)
        {
            return _roles.GetById(id);
        }
    }
}
