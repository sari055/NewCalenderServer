using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public enum UserType
    {
        Admin,
        Editor,
        Viewer
    }

    public class CalenderUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CalenderId { get; set; }
        [Required]
        public UserType UserType { get; set; }


        public User User { get; set; }
        public Calender Calender { get; set; }


        //[Required]
        //public int LevelId { get; set; }
        //[Required]
        //public int FamilyId { get; set; }
    }
}
