using System;

namespace CalendarApp.WebAPI.Models
{
    public class YearEventModel
    {
        public int EventId { get; set; }
        public int CalenderId { get; set; }
        public DateTime GregorianDate { get; set; }
    }
}
