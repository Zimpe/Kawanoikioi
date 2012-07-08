using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kawanoikioi.Models
{
    public class ChatMessages
    {
        public int ID { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string AuthorID { get; set; }
        [Required]
        public int ChatRoomID { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
    }
}