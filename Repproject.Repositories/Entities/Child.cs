using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repproject.Repositories.Entities
{
    public class Child
    {
        
        public int ChildId { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Tz { get; set; }
        [ForeignKey("IdParent")]
        public virtual Parent Parent{ get; set; }
        public int? IdParent { get; set; }       
    }
}
