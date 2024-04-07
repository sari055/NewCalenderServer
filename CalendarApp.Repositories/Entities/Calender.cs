using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Calender
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DirectorId { get; set; }
        public string GroupName { get; set; }


        public User Director { get; set; }
        public List<CalenderUser> CalenderUsers { get; set; }
        public List<CalenderYear> CalenderYears { get; set; }
        public List<Event> Events { get; set; }

    }
}
