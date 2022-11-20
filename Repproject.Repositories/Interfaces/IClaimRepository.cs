using Repproject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IClaimRepository
    {
        List<Claim> GetAll();

        Claim GetById(int id);

        Claim Add(int id, int idr, int idp);

        Claim Update(Claim role);

        void Delete(int id);
    }
}
