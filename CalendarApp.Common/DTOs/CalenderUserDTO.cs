using CalendarApp.Common.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Repositories.Entities
{
    public enum UserTypeDTO
    {
        Admin,
        Editor,
        Viewer
    }

    public class CalenderUserDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CalenderId { get; set; }
        public UserTypeDTO UserType { get; set; }


        public UserDTO User { get; set; }
        public CalenderDTO Calender { get; set; }
        //public int LevelId { get; set; }
        //public int FamilyId { get; set; }
    }


}
