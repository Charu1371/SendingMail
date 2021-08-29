using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendingMail.Models
{
    public class EmailClass
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
      
    }
}