using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class Job
    {
        public int id { get; set; }
        public string JobTittle { get; set; }
        public string JobContent { get; set; }
        public string JobImage { get; set; }
        
        public int CategoryId { get; set; }
        public string UserId { get; set; }
        public virtual Category category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}