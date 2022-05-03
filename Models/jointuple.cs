using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class jointuple
    {
        public int id { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Testemonials> testemonials { get; set; }
        public IEnumerable<Job> job { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}