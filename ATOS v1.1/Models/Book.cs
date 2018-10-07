using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ATOS_v1._1.Models
{
    public class Book
    {
        [Key]
        public int IdBook { get; set; }
        public int IdRoom { get; set; }
        public string Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Status { get; set; }
    }
}