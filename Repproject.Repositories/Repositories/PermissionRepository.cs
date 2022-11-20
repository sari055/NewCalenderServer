using Repproject.Repositories.Entities;
using Repproject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        readonly IContext _context;

        public PermissionRepository(IContext context)
        {
            _context = context;
        }

        public Permission Add(int id, string name)
        {
            Permission temp = new Permission() { Id = id, Name = name };
            _context.permissions.Add(temp);
            return temp;
        }

        public void Delete(int id)
        {
            for (int i = 0; i < _context.permissions.Count; i++)
            {
                if (_context.permissions[i].Id == id)
                {
                    _context.permissions.RemoveAt(id);
                    return;
                }
            }
        }

        public List<Permission> GetAll()
        {
            return _context.permissions;
        }

        public Permission GetById(int id)
        {
            for (int i = 0; i < _context.permissions.Count; i++)
            {
                if (_context.permissions[i].Id == id)
                    return _context.permissions[i];
            }
            return new Permission();
        }

        public Permission Update(Permission permission)
        {
            for (int i = 0; i < _context.permissions.Count; i++)
            {
                if (_context.permissions[i].Id == permission.Id)
                    _context.permissions[i] = permission;
            }
            return permission;
        }
    }
}
