using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kawanoikioi.Models
{
    public class Forum
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string UniqueName { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public int OrderID { get; set; }
    }
}