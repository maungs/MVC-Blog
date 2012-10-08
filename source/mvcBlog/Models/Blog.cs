using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcBlog.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Article { get; set; }
        [DataType(DataType.MultilineText)]
        public string Quote { get; set; }
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string ArticleImage { get; set; }
        public string ImageDescription { get; set; }
        public string HeaderImage { get; set; }
        public bool NoComments { get; set; }
        public bool IsDraft { get; set; }
        public bool IsPublished { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SocialBlogStat> SocialBlogStats { get; set; }

    }
    public class BlogCategoryModel
    {
        [DisplayName("Items")]
        public string[] SelectedItemIds { get; set; }
        public IEnumerable<Category> Items { get; set; }
    }
}