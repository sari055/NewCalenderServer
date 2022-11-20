using Repproject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IPermissionRepository
    {
        List<Permission> GetAll();

        Permission GetById(int id);

        Permission Add(int id, string name);

        Permission Update(Permission role);

        void Delete(int id);
    }
}
