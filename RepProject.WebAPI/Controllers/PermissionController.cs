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
    public class PermissionController : ControllerBase
    {
        readonly IPermissionService _permission;

        public PermissionController(IPermissionService permission)
        {
            _permission = permission;
        }

        [HttpGet]
        public List<PermissionDTO> GetAll()
        {
            return _permission.GetAll();
        }

        [HttpGet("{id}")]
        public PermissionDTO Get(int id)
        {
            return _permission.GetById(id);
        }
    }
}
