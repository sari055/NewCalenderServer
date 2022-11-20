using RepProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Interfaces
{
    public interface IClaimService
    {
        List<ClaimDTO> GetAll();

        ClaimDTO GetById(int id);

        ClaimDTO Add(int id, int idr, int idp);

        ClaimDTO Update(ClaimDTO role);

        void Delete(int id);
    }
}
