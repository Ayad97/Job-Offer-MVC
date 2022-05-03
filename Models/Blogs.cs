using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class Blogs
    {
        public int id { get; set; }
        public string BlogImage { get; set; }
        public string BlogTittle { get; set; }
        public string BlogArticle { get; set; }
        public string Blog_Id { get; set; }
        public DateTime ReturnDate { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}