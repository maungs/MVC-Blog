using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcBlog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required]
        public string CommentText { get; set; }

        public int BlogId { get; set; }

        public virtual Blog Blog { get; set; }
    }
}