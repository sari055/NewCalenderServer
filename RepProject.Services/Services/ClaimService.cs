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
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claim;
        private readonly IMapper _mapper;

        public ClaimService(IClaimRepository claim, IMapper mapper)
        {
            _claim = claim;
            _mapper = mapper;
        }

        public ClaimDTO Add(int id, int idr, int idp)
        {
            _claim.Add(id, idr, idp);
            return new ClaimDTO { Id = id, IdRole = idr, IdPermission = idp };
        }

        public void Delete(int id)
        {
            _claim.Delete(id);
        }

        public List<ClaimDTO> GetAll()
        {
            return _mapper.Map<List<ClaimDTO>>(_claim.GetAll());
        }

        public ClaimDTO GetById(int id)
        {
            return _mapper.Map<ClaimDTO>(_claim.GetById(id));
        }

        public ClaimDTO Update(ClaimDTO claim)
        {
            return _mapper.Map<ClaimDTO>(_claim.Update(_mapper.Map<Claim>(claim)));
        }
    }
}
