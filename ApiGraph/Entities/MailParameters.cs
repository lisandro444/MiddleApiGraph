using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGraph.Entities
{
    public class MailParameters
    {
        public string subject { get; set; }
        public string mailTo { get; set; }
        public string body { get; set; }
    }
}