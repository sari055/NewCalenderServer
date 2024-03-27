using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp.Common.DTOs
{
    public class YearEventDTO
    {
        public int EventId { get; set; }
        public int CalenderId { get; set; }
        public DateTime GregorianDate { get; set; }
    }
}
