using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Level
    {
        [Required]
        public int Id { get; set; }
        public string LevelName { get; set; }
        [Required]
        public int Sort { get; set; }

    }
}
