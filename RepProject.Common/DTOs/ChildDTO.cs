using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepProject.Common.DTOs
{
    public class ChildDTO
    {

        public int ChildId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Tz { get; set; }
       // [ForeignKey("Parent")]
        public int IdParent { get; set; }
        public ParentDTO Parent { get; set; }
    }
}
