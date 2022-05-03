using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class Testemonials
    {
        public int id { get; set; }
        public string message { get; set; }
        public string image { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        
    }
}