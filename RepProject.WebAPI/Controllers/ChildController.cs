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
using System.Linq;
using System.Threading.Tasks;


namespace RepProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        readonly IChildService _child;
      

        public ChildController(IChildService childService)
        {
            _child = childService;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<ChildDTO>> Get()
        {
            return await _child.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ChildDTO> GetById(int id)
        {
            return await _child.GetByIdAsync(id);
        }
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _child.DeleteAsync(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody] ChildModel child)
        {
            await _child.AddAsync(new ChildDTO {  Name= child.Name,DateOfBirth=child.DateOfBirth,Tz=child.Tz,IdParent=child.IdParent});
        }
        [HttpPut]
        public async Task Put(ChildDTO child)
        {
            await _child.UpdateAsync(child);
        }
    }
}
