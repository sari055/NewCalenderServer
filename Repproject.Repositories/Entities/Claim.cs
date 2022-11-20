using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Entities
{
    public class Claim
    {
        public int Id { get; set; }

        public int IdRole { get; set; }

        public int IdPermission { get; set; }
    }
}
