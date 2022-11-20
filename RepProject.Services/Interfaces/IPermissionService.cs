using RepProject.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Services.Interfaces
{
    public interface IPermissionService
    {
        List<PermissionDTO> GetAll();

        PermissionDTO GetById(int id);

        PermissionDTO Add(int id, string name);

        PermissionDTO Update(PermissionDTO role);

        void Delete(int id);
    }
}
