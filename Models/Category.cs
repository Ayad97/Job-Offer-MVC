using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class Category
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public virtual ICollection<Job>jobs { get; set; }
       
    }
}