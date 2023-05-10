using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ParentController : ControllerBase
    {
        readonly IParentService _parent;

        public ParentController(IParentService parentService)
        {
            _parent = parentService;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IEnumerable<ParentDTO>> Get()
        {
            return await _parent.GetListAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ParentDTO> GetById(int id)
        {
            return await _parent.GetByIdAsync(id);
        }
        [HttpGet("tz/{tz}")]
        public async Task<int> GetByTz( string tz)
        {

         
            return await _parent.GetByTzAsync(tz);
        }
       
        [HttpDelete]
        public async Task Delete(int id)
        {
            await _parent.DeleteAsync(id);
        }
        [HttpPost]
        public async Task Post([FromBody] ParentModel parent)
        {

            //DateTime.TryParse(dateOfBirth,out DateTime convertedDate);
            await _parent.AddAsync(new ParentDTO
            {
             
                FirstName =parent.FirstName,
                LastName=parent.LastName,
                DateOfBirth = parent.DateOfBirth,
                Type = parent.Type,
                Tz = parent.Tz,
                //ChildrenId = childrenId,
                HMO = parent.HMO,
            }) ;
        }
        [HttpPut]
        public async Task Put(ParentDTO parent)
        {
            await _parent.UpdateAsync(parent);

        }
    }
}
