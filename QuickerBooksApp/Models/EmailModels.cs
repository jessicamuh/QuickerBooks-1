using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickerBooksApp.Models
{
    public class EmailModels
    {
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}