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
    public class ClaimController : ControllerBase
    {
        readonly IClaimService _claim;

        public ClaimController(IClaimService claim)
        {
            _claim = claim;
        }

        [HttpGet]
        public List<ClaimDTO> GetAll()
        {
            return _claim.GetAll();
        }

        [HttpGet("{id}")]
        public ClaimDTO Get(int id)
        {
            return _claim.GetById(id);
        }

        [HttpPost]
        public ClaimDTO Add(int id, int idr, int idp)
        {
            return _claim.Add(id, idr, idp);
        }

        [HttpPut("{c}")]
        public ClaimDTO Update(ClaimDTO c)
        {
            return _claim.Update(c);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _claim.Delete(id);
        }
    }
}
