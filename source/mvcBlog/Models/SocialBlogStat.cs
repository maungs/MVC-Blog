using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcBlog.Models
{
    public class SocialBlogStat
    {
        public int Id { get; set; }

        [Required]
        public string SocialSite { get; set; }

        public int SharedCount { get; set; }

        public bool isActive { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}