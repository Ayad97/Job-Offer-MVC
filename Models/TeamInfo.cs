using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class TeamInfo
    {
        public int id { get; set; }

        public string TeamImage { get; set; }
        public string TeamUsername { get; set; }
        public string TeamWorkTittle { get; set; }
        public string TeamAbout{ get; set; }

        [Display(Name = "Facebook Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]         
        public string TeamEmailF{ get; set; }
        [Display(Name = "Twitter Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string TeamEmailT{ get; set; }
        [Display(Name = "Instagram Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string TeamEmailI{ get; set; }
        [Display(Name = "LinkedIn Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string TeamEmailL{ get; set; }

        
        

    }
}