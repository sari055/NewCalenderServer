using Repproject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Interfaces
{
    public interface IContext
    {
        List<Role> roles { get; set; }

        List<Permission> permissions { get; set; }

        public List<Claim> claims { get; set; }
    }
}
