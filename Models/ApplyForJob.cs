using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class ApplyForJob
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public String UserId { get; set; }
        public string Message { get; set; }
        public DateTime ApplyDate { get; set; }



        public virtual Job job { get; set; }
        public virtual ApplicationUser User { get; set; } 

    }
}