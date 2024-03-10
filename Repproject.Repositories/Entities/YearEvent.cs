using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class YearEvent
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CalenderId { get; set; }
        public DateTime GregorianDate { get; set; }
    }
}
