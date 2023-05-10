using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Entities
{
    public class Parent
    {
        [Required]
      
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Tz { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string HMO { get; set; }
        



    }
}
