using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        readonly IContext _context;

        public RoleRepository(IContext context)
        {
            _context = context;
        }

        public Role Add(int id, string name)
        {
            Role temp = new Role() { Id = id, Name = name };
            _context.roles.Add(temp);
            return temp;
        }

        public void Delete(int id)
        {
            for (int i = 0; i < _context.roles.Count; i++)
            {
                if (_context.roles[i].Id == id)
                {
                    _context.roles.RemoveAt(id);
                    return;
                }
            }
        }

        public List<Role> GetAll()
        {
            return _context.roles;
        }

        public Role GetById(int id)
        {
            for (int i = 0; i < _context.roles.Count; i++)
            {
                if (_context.roles[i].Id == id)
                    return _context.roles[i];
            }
            return new Role();
        }

        public Role Update(Role role)
        {
            for (int i = 0; i < _context.roles.Count; i++)
            {
                if (_context.roles[i].Id == role.Id)
                    _context.roles[i] = role;
            }
            return role;
        }
    }
}
