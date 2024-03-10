using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class CalenderUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserType { get; set; }
        public int LevelId { get; set; }
        public int FamilyId { get; set; }
    }
}
