using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATOS_v1._1.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Count chairs")]
        public int CountChair { get; set; }
        [Display(Name = "Blackboard")]
        public bool IsBlackboard { get; set; }
        [Display(Name = "Projector")]
        public bool IsProjector { get; set; }
        public string Description { get; set; }
    }
}