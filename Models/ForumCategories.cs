using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kawanoikioi.Models
{
    public class ForumCategories
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int OrderID { get; set; }
    }
}