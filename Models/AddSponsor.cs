using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class AddSponsor
    {
        public int id { get; set; }
        public string sponsorImage { get; set; }
        public string sponsorTittle { get; set; }
        public string sponsorContent { get; set; }
    }
}