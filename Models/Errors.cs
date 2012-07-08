using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kawanoikioi.Models
{
    public class Errors
    {
        public int ID { get; set; }
        public string Source { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerException { get; set; }
        public string UserComment { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}