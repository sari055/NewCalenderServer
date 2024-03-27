using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class YearEvent
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int CalenderId { get; set; }
        [Required]
        public DateTime GregorianDate { get; set; }
    }
}
