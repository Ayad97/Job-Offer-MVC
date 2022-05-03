using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASP_IDENTITY.Models
{
    public class Article
    {
        public int id { get; set; }
        public string BlogImage { get; set; }
        public string BlogTittle { get; set; }
        public string BlogArticle { get; set; }
        public string Blog_Id { get; set; }
        public DateTime ReturnDate { get; set; }

        [ForeignKey("Blog_Id")]
        public virtual ApplicationUser User { get; set; }

    }
}