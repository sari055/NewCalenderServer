using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserTZ { get; set; }
        [Required]
        public int UserSpouseID { get; set; }
        [Required]
        public int UserFatherID { get; set; }
        [Required]
        public int UserMotherID { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
