﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kawanoikioi.Models
{
    public class Articles
    {
        public int ID { get; set; }
        [Required]
        public string UniqueName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public bool IsPublished { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        public DateTime LastModified { get; set; }
    }
}