using Repproject.Repositories.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace RepProject.WebAPI.Models
{
    public class ChildModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Tz { get; set; }
        public int IdParent { get; set; }
    }
}
