using System.ComponentModel.DataAnnotations;
using System;

namespace RepProject.WebAPI.Models
{
    public class ParentModel
    {
  
        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public string Tz { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        public string Type { get; set; }
     
        public string HMO { get; set; }
    }
}
