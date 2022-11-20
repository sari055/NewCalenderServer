using Repproject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> GetAll();

        Role GetById(int id);

        Role Add(int id, string name);

        Role Update(Role role);

        void Delete(int id);
    }
}
