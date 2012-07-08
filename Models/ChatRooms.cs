using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kawanoikioi.Models
{
    public class ChatRooms
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Topic { get; set; }
    }
}