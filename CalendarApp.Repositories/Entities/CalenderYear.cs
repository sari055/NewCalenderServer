using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository.Entities
{
    public class CalenderYear
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CalenderId { get; set; }
        [Required]
        public int Year { get; set; }


        public Calender Calender { get; set; }

    }
}

