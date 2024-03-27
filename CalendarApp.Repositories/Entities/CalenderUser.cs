using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class CalenderUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string UserType { get; set; }
        [Required]
        public int LevelId { get; set; }
        [Required]
        public int FamilyId { get; set; }
    }
}
