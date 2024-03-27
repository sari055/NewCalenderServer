using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Entities
{
    public class UserModel
    {
        public int UserTZ { get; set; }
        public int UserSpouseID { get; set; }
        public int UserFatherID { get; set; }
        public int UserMotherID { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
