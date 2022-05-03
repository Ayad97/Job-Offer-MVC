using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class Contact
    {
        public int id { get; set; }
        
        public string Username { get; set; }
        public string Email { get; set; }
        public string message { get; set; }
        public string ContactID { get; set; }

        [ForeignKey("ContactID")]
        public virtual ApplicationUser User { get; set; }
    }
}