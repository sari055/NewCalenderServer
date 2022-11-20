using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        readonly IContext _context;

        public ClaimRepository(IContext context)
        {
            _context = context;
        }

        public Claim Add(int id, int idr, int idp)
        {
            var temp = new Claim { Id = id, IdRole = idr, IdPermission = idp };
            _context.claims.Add(temp);
            return temp;
        }

        public void Delete(int id)
        {
            for (int i = 0; i < _context.claims.Count; i++)
            {
                if (_context.claims[i].Id == id)
                {
                    _context.claims.RemoveAt(id);
                    return;
                }
            }
        }

        public List<Claim> GetAll()
        {
            return _context.claims;
        }

        public Claim GetById(int id)
        {
            for (int i = 0; i < _context.claims.Count; i++)
            {
                if (_context.claims[i].Id == id)
                    return _context.claims[i];
            }
            return new Claim();
        }

        public Claim Update(Claim claim)
        {
            for (int i = 0; i < _context.claims.Count; i++)
            {
                if (_context.claims[i].Id == claim.Id)
                    _context.claims[i] = claim;
            }
            return claim;
        }
    }
}
