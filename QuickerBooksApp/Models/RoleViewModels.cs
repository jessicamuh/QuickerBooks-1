using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickerBooksApp.Models
{
   
        public class EmailViewModel
        {

            [Required]
            [EmailAddress]
            [Display(Name = "From")]
            public string From { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "To")]
            public string To { get; set; }

            [EmailAddress]
            [Display(Name = "CC")]
            public string CC { get; set; }

            [Required]
            [Display(Name = "Subject")]
            public string Subject { get; set; }

            [Required]
            [Display(Name = "Body")]
            public string Body { get; set; }
        }
    }
