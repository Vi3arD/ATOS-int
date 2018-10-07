using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATOS_v1._1.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public string NameUser { get; set; }
        public int IdBook { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
    }
}