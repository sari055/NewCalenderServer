using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Repository.Entities
{
    public class CalenderYear
    {

        public int Id { get; set; }
        public int CalenderId { get; set; }
        public int Year { get; set; }

    }
}

