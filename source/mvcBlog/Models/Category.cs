using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcBlog.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string SecondaryImage { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}