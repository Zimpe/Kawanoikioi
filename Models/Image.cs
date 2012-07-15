using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kawanoikioi.Models
{
    public class Image
    {
        public int ID { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public byte[] FileData { get; set; }
        [Required]
        public string MimeType { get; set; }
        [Required]
        public string Uploader { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
    }
}